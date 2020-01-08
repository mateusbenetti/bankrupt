using Bankrupt.Data.Context;
using Bankrupt.Data.Model.Interface;
using Bankrupt.Data.Repository;
using System;

namespace Bankrupt.Data.Model.Repository
{
    public class BoardHouseRepository : Repository<BoardHouseInfo>, IBoardHouseRepository
    {
        public BoardHouseRepository(BankruptContext bankruptContext) : base(bankruptContext)
        {
        }
    }
}
