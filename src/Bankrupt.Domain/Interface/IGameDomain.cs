using System.Collections.Generic;
using Bankrupt.Model;
using Bankrupt.Model.Enum;
using Bankrupt.Model.Interface;

namespace Bankrupt.Domain.Interface
{
    public interface IGameDomain
    {
        BoardGame StartGame(IDictionary<int, IPlayer> players, string pathConfigFile, int? maxRound);
        void LetsPlay(BoardGame boardGame);
        void FinishGame(BoardGame boardGame, int? maxRound);
    }
}
