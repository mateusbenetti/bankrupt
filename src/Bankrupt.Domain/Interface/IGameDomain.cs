using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Bankrupt.Domain.Model;
using Bankrupt.Domain.Model.Enum;
using Bankrupt.Domain.Model.Interface;

namespace Bankrupt.Domain.Interface
{
    public interface IGameDomain
    {
        BoardGame StartGame(IDictionary<int, IPlayer> players, string pathConfigFile, int? maxRound, string registerCode);
        void LetsPlay(BoardGame boardGame, System.Guid gameId);
        void FinishGame(BoardGame boardGame, int? maxRound, string registerCode, System.Guid gameId);
        void RegisterStatisticalAnalysis(string registerCode);
        Task SaveRegisterRoundAsync(BoardGameRoundRegister registerRound, CancellationToken cancellationToken);
    }
}
