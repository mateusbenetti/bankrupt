using Bankrupt.Data.Context;
using Bankrupt.Data.Model.Interface;
using Bankrupt.Data.Repository;
using Microsoft.Extensions.Configuration;

namespace Bankrupt.Data.Model.Repository
{
    public class PossesionRepository : Repository<PossesionInfo>, IPossesionRepository
    {
        public PossesionRepository(BankruptContext bankruptContext, IConfiguration configuration) 
            : base(bankruptContext, configuration)
        {
        }

        public override string EntityName => "Possesions";
    }
}