using Bankrupt.Data.Context;
using Bankrupt.Data.Model.Interface;
using Bankrupt.Data.Repository;
using System;

namespace Bankrupt.Data.Model.Repository
{
    public class PlayerRepository : Repository<PlayerInfo>, IPlayerRepository
    {
        public PlayerRepository(BankruptContext bankruptContext) : base(bankruptContext)
        {
        }
    }
}
