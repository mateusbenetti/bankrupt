
using Bankrupt.Data.Context;
using Bankrupt.Data.Model.Interface;
using Bankrupt.Data.Repository;
using Microsoft.Extensions.Configuration;

namespace Bankrupt.Data.Model.Repository
{
    public class BoardGameRepository : Repository<BoardGameInfo>, IBoardGameRepository
    {
        public BoardGameRepository(BankruptContext bankruptContext, IConfiguration configuration) 
            : base(bankruptContext, configuration)
        {
        }
        public override string EntityName => "BoardGames";
    }
}