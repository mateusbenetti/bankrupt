using System.Collections.Generic;
using Bankrupt.Application.Model;
using Bankrupt.Model.Enum;

namespace Bankrupt.Application.Interface
{
    public interface IGameService
    {
        IList<GameResultView> PlayBankrupt(string pathConfig);
        IDictionary<PlayerType, string> GetPlayerTypes();
        int GetMaxRoundsByGame();
        int GetNumberOfGames();
    }
}