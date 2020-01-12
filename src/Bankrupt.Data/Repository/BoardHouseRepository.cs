using Bankrupt.Data.Context;
using Bankrupt.Data.Model.Interface;
using Bankrupt.Data.Repository;
using Microsoft.Extensions.Configuration;
using System;

namespace Bankrupt.Data.Model.Repository
{
    public class BoardHouseRepository : Repository<BoardHouseInfo>, IBoardHouseRepository
    {
        public BoardHouseRepository(BankruptContext bankruptContext, IConfiguration configuration) 
            : base(bankruptContext, configuration)
        {
        }
        public override string EntityName => "BoardHouses";
    }
}
