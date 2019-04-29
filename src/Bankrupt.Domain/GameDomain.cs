﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Bankrupt.Domain.Interface;
using Bankrupt.Domain.Resources;
using Bankrupt.Model;
using Bankrupt.Model.Enum;
using Bankrupt.Model.Interface;

namespace Bankrupt.Domain
{
    public class GameDomain : IGameDomain
    {
        private readonly IPlayerDomain _playerDomain;
        public GameDomain(IPlayerDomain playerDomain)
        {
            _playerDomain = playerDomain;
        }

        public BoardGame StartGame(IDictionary<int, IPlayer> players, string pathConfigFile, int? maxRound)
        {
            var boardGame = new BoardGame(players, BuildBoardHouseCollection(pathConfigFile), maxRound);
            boardGame.LastBoardHouse.Next = boardGame.FirstBoardHouse;
            PutPlayersInBoardGame(players, boardGame);
            return boardGame;
        }
        public void LetsPlay(BoardGame boardGame)
        {
            bool continuePlaying;
            boardGame.Round = 1;
            do
            {
                Round(boardGame, _playerDomain);
                continuePlaying = ContinuePlaying(boardGame, boardGame.Round);
                if (continuePlaying)
                    boardGame.Round++;
            } while (continuePlaying);
        }
        public void FinishGame(BoardGame boardGame, int? maxRound)
        {
            var boardGameResult = new BoardGameResult()
            {
                Rounds = boardGame.Round,
                TimeOut = maxRound.HasValue && maxRound == boardGame.Round,
                WinnerType = GetWinner(boardGame)
            };
            boardGame.Result = boardGameResult;
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
        private static void Round(BoardGame boardGame, IPlayerDomain playerDomain)
        {
            var players = boardGame.Players.OrderBy(p => p.Key).Select(p => p.Value).ToList();
            foreach (var player in players)
            {
                playerDomain.Play(player, boardGame);
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
    }
}