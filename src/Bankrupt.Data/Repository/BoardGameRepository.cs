
using Bankrupt.Data.Context;
using Bankrupt.Data.Model.Interface;
using Bankrupt.Data.Repository;

namespace Bankrupt.Data.Model.Repository
{
    public class BoardGameRepository : Repository<BoardGameInfo>, IBoardGameRepository
    {
        public BoardGameRepository(BankruptContext bankruptContext) : base(bankruptContext)
        {
        }
    }
}