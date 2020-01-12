using System.Collections.Generic;
using Bankrupt.Domain.Model;
using Bankrupt.Domain.Model.Enum;
using Bankrupt.Domain.Model.Interface;

namespace Bankrupt.Domain.Interface
{
    public interface IGameDomain
    {
        BoardGame StartGame(IDictionary<int, IPlayer> players, string pathConfigFile, int? maxRound, string registerCode);
        void LetsPlay(BoardGame boardGame);
        void FinishGame(BoardGame boardGame, int? maxRound);
    }
}
