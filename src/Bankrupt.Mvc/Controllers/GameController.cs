using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bankrupt.Application.Interface;
using Bankrupt.Application.ViewModel;
using Bankrupt.Mvc.Models;
using Bankrupt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Bankrupt.Mvc.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameService _service;
        private readonly AppSettings _appSettings;
        public IBackgroundTaskQueue _queue { get; }
        public GameController(IGameService service, IOptions<AppSettings> appSettings, IBackgroundTaskQueue queue)
        {
            _appSettings = appSettings.Value;
            _service = service;
            _queue = queue;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var maxRounds = _service.GetMaxRoundsByGame();
            var numberOfGames = _service.GetNumberOfGames();
            var results = _service.PlayBankrupt(_appSettings.GameConfigFilePath);
            var model = new GameModel
            {
                WinsByPlayerType = GetPercentWinByPlayerType(_service, results),
                AmountFinishedByTimeout = results.Count(p => p.TimeOut),
                AverageRounds = results.Sum(p => p.Rounds) / numberOfGames,
                NumberOfGames = numberOfGames,
                MaxRoundByGames = maxRounds,
                RegisterCode = results.First().RegisterCode
            };
            model.PlayersTypeMostWinner = GetPlayersTypeMostWinner(model.WinsByPlayerType);
            List<GameResultRoundRegisters> gameResultRoundRegisters = new List<GameResultRoundRegisters>();
            _queue.QueueBackgroundWorkItem(async token =>
            {
                await SaveRegisterRound(gameResultRoundRegisters, results, token);
            });
            return View(model);
        }

        private async Task SaveRegisterRound(List<GameResultRoundRegisters> gameResultRoundRegisters, IList<GameResultView> results, System.Threading.CancellationToken token)
        {
            foreach (var item in results)
                gameResultRoundRegisters.AddRange(item.RoundRegisters);
            foreach (var item in gameResultRoundRegisters)
               await _service.SaveRegisterRound(item, token);
            await Task.FromResult(true);
        }
        private static IDictionary<string, int> GetPercentWinByPlayerType(IGameService service, IList<GameResultView> result)
        {
            return service.GetPlayerTypes().
                ToDictionary(playerType => playerType.Value,
                playerType => result.Count(p => p.WinnerType == playerType.Key));
        }

        private static List<string> GetPlayersTypeMostWinner(IDictionary<string, int> winsByPlayerType)
        {
            var maxWins = winsByPlayerType.Max(p => p.Value);
            return winsByPlayerType.Where(p => p.Value == maxWins).Select(player => player.Key).ToList();
        }
    }
}