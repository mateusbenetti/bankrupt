using Bankrupt.Data.Context;
using Bankrupt.Data.Model.Interface;
using Bankrupt.Data.Repository;

namespace Bankrupt.Data.Model.Repository
{
    public class PossesionRepository : Repository<PossesionInfo>, IPossesionRepository
    {
        public PossesionRepository(BankruptContext bankruptContext) : base(bankruptContext)
        {
        }
    }
}
