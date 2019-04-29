using Bankrupt.Model;
using Bankrupt.Model.Interface;

namespace Bankrupt.Domain.Interface
{
    public interface IPlayerDomain
    {
        void Play(IPlayer player, BoardGame boardGame);
    }
}