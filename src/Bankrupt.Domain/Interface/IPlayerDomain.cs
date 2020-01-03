using Bankrupt.Domain.Model;
using Bankrupt.Domain.Model.Interface;

namespace Bankrupt.Domain.Interface
{
    public interface IPlayerDomain
    {
        void Play(IPlayer player, BoardGame boardGame);
    }
}