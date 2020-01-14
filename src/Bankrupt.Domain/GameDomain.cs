using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Bankrupt.Domain.Interface;
using Bankrupt.Domain.Resources;
using Bankrupt.Domain.Model;
using Bankrupt.Domain.Model.Enum;
using Bankrupt.Domain.Model.Interface;
using Bankrupt.Data.Model.Interface;
using Bankrupt.Data.Model;
using Bankrupt.Data.Model.Enum;
using System.Threading;
using System.Threading.Tasks;

namespace Bankrupt.Domain
{
    public class GameDomain : IGameDomain
    {
        private readonly IPlayerDomain _playerDomain;
        private readonly IBoardGameRepository _boardGameRepository;
        private readonly IPlayerRepository _playerRepository;
        private readonly IStatisticalAnalysisRepository _statisticalAnalysisRepository;
        private readonly IRoundRegisterRepository _roundRegisterRepository;
        private readonly IUnitOfWork _unitOfWork;
        public GameDomain(IPlayerDomain playerDomain, IUnitOfWork unitOfWork,
            IPlayerRepository playerRepository,
            IBoardGameRepository boardGameRepository,
            IStatisticalAnalysisRepository statisticalAnalysisRepository, IRoundRegisterRepository roundRegisterRepository)
        {
            _playerDomain = playerDomain;
            _unitOfWork = unitOfWork;
            _playerRepository = playerRepository;
            _boardGameRepository = boardGameRepository;
            _statisticalAnalysisRepository = statisticalAnalysisRepository;
            _roundRegisterRepository = roundRegisterRepository;
        }

        public BoardGame StartGame(IDictionary<int, IPlayer> players, string pathConfigFile, int? maxRound, string registerCode)
        {
            var boardGame = new BoardGame(players, BuildBoardHouseCollection(pathConfigFile), maxRound, registerCode);
            boardGame.LastBoardHouse.Next = boardGame.FirstBoardHouse;
            PutPlayersInBoardGame(players, boardGame);
            return boardGame;
        }
        public void LetsPlay(BoardGame boardGame, Guid gameId)
        {
            bool continuePlaying;
            boardGame.Round = 1;
            do
            {
                Round(boardGame, _playerDomain, gameId);
                continuePlaying = ContinuePlaying(boardGame, boardGame.Round);
                if (continuePlaying)
                    boardGame.Round++;
            } while (continuePlaying);
        }
        public void FinishGame(BoardGame boardGame, int? maxRound, string registerCode, Guid gameId)
        {
            var boardGameResult = new BoardGameResult()
            {
                Rounds = boardGame.Round,
                TimeOut = maxRound.HasValue && maxRound == boardGame.Round,
                WinnerType = GetWinner(boardGame),
                RoundRegisters = boardGame.RoundRegisters.Select(p => new BoardGameRoundRegister()
                {
                    Action = p.Action,
                    BoardHouseAfter = p.BoardHouseAfter,
                    CoinsAfter = p.CoinsAfter,
                    BoardGameId = p.BoardGameId,
                    BoardHouseBefore = p.BoardHouseBefore,
                    CoinsBefore = p.CoinsBefore,
                    Player = p.Player
                }).ToList()
            };
            boardGame.Result = boardGameResult;
            SaveGame(boardGame, registerCode, gameId);
        }

        private void SaveGame(BoardGame boardGame, string registerCode, Guid gameId)
        {
            var statisticalAnalysisInfo = _statisticalAnalysisRepository.GetRegisterCode(registerCode);
            var registerRounds = new List<RoundRegisterInfo>();
            _boardGameRepository.Add(new BoardGameInfo()
            {
                Id = gameId,
                RegisterCode = boardGame.RegisterCode,
                NumberRound = boardGame.Round,
                WinnerId = GetPlayer(boardGame.Result.WinnerType),
                StatisticalAnalysisId = statisticalAnalysisInfo.Id,
                RoundRegisters = registerRounds
            });
            _unitOfWork.Commit();
        }

        private Guid GetPlayer(PlayerType winnerType)
        {
            var playerTypeEnum = ConvertPlayerType(winnerType);
            var playerInfo = _playerRepository.GetPlayer(playerTypeEnum);
            return playerInfo.Id;
        }

        private PlayerTypeEnum ConvertPlayerType(PlayerType winnerType)
        {
            switch (winnerType)
            {
                case PlayerType.Random:
                    return PlayerTypeEnum.Random;
                case PlayerType.Impulsive:
                    return PlayerTypeEnum.Impulsive;
                case PlayerType.Cautious:
                    return PlayerTypeEnum.Cautious;
                case PlayerType.Demanding:
                    return PlayerTypeEnum.Demanding;
                default:
                    return PlayerTypeEnum.None;
            }
        }

        private static IList<BoardHouse> BuildBoardHouseCollection(string pathConfigFile)
        {
            IList<BoardHouse> houses = new List<BoardHouse>();
            var configInformation = ReadConfigFile(pathConfigFile);
            ValidFileConfig(configInformation);
            var boardHouse = new BoardHouse();
            for (var i = 0; i < configInformation.Length; i++)
            {
                var line = configInformation[i];
                var sequential = i + 1;
                boardHouse = BuildBoardHouse(line, boardHouse, sequential);
                houses.Add(boardHouse);
            }
            return houses;
        }
        private static BoardHouse BuildBoardHouse(string line, BoardHouse previousHouse, int sequential)
        {
            var purchaseConfig = line.Substring(0, 3).Trim();
            var rentConfig = line.Substring(3, 3).Trim();
            var boardHouse = new BoardHouse()
            {
                Sequential = sequential,
                RentValue = int.Parse(rentConfig),
                PurchaseValue = int.Parse(purchaseConfig),
            };
            previousHouse.Next = boardHouse;
            return boardHouse;
        }
        private static void ValidFileConfig(string[] configInformation)
        {
            foreach (var line in configInformation)
            {
                if (line.Trim().Length % 6 != 0)
                    throw new InvalidDataException(GameResource.InvalidConfigFile);
                var validChars = line.ToCharArray().Where(p => p != ' ');
                foreach (var character in validChars)
                    if (!int.TryParse(character.ToString(), out _))
                        throw new InvalidDataException(GameResource.InvalidDataType);
            }
        }
        private static string[] ReadConfigFile(string pathConfigFile)
        {
            var configInformation = new List<string>();
            using (var readerFileConfig = new StreamReader(pathConfigFile))
                while (readerFileConfig.Peek() >= 0)
                    configInformation.Add(readerFileConfig.ReadLine());

            return configInformation.ToArray();
        }
        private static void PutPlayersInBoardGame(IDictionary<int, IPlayer> players, BoardGame boardGame)
        {
            foreach (var player in players.Values)
            {
                player.CurrentBoardHouse = boardGame.FirstBoardHouse;
                player.Playing = true;
            }
        }
        private static void Round(BoardGame boardGame, IPlayerDomain playerDomain, Guid gameId)
        {
            var players = boardGame.Players.OrderBy(p => p.Key).Select(p => p.Value).ToList();
            foreach (var player in players)
            {
                playerDomain.Play(player, boardGame, gameId);
                if (players.Count(p => p.Playing) == 1)
                    break;
            }
        }
        private static bool ContinuePlaying(BoardGame boardGame, int round)
        {
            var play = true;
            if (boardGame.MaxRound != null)
                play = round < boardGame.MaxRound;
            if (play)
                play = boardGame.Players.Values.Count(p => p.Playing) > 1;
            return play;
        }
        private static PlayerType GetWinner(BoardGame boardGame)
        {
            IPlayer winner;
            if (boardGame.Players.Values.Count(p => p.Playing) == 1)
                winner = boardGame.Players.Values.Single(p => p.Playing);
            else
            {
                var maxCoins = boardGame.Players.Max(p => p.Value.Coins);
                winner = boardGame.Players.OrderBy(p => p.Key).Select(p => p.Value)
                    .First(p => p.Coins == maxCoins);
            }
            return winner.Type;
        }
        public void RegisterStatisticalAnalysis(string registerCode)
        {
            _statisticalAnalysisRepository.Add(new StatisticalAnalysisInfo()
            {
                Id = Guid.NewGuid(),
                RegisterCode = registerCode,
                Date = DateTime.Now
            });
            _unitOfWork.Commit();
        }

        public async Task SaveRegisterRoundAsync(BoardGameRoundRegister registerRound, CancellationToken cancellationToken)
        {
            _roundRegisterRepository.Add(new RoundRegisterInfo()
            {
                Action = registerRound.Action,
                BoardGameId = registerRound.BoardGameId,
                BoardHouseAfter = registerRound.BoardHouseAfter,
                BoardHouseBefore = registerRound.BoardHouseBefore,
                CoinsAfter = registerRound.CoinsAfter,
                CoinsBefore = registerRound.CoinsBefore,
                PlayerId = GetPlayer(registerRound.Player.Type)
            });
            _unitOfWork.Commit();
            await Task.FromResult(true);
        }
    }
}