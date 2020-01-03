using System.Collections.Generic;
using System.Linq;
using Bankrupt.Application.Interface;
using Bankrupt.Application.ViewModel;
using Bankrupt.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Bankrupt.Mvc.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameService _service;
        private readonly AppSettings _appSettings;
        public GameController(IGameService service, IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
            _service = service;
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
                MaxRoundByGames = maxRounds
            };
            model.PlayersTypeMostWinner = GetPlayersTypeMostWinner(model.WinsByPlayerType);
            return View(model);
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