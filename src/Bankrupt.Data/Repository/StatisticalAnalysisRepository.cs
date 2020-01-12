using Bankrupt.Data.Context;
using Bankrupt.Data.Model.Interface;
using Bankrupt.Data.Repository;
using Microsoft.Extensions.Configuration;

namespace Bankrupt.Data.Model.Repository
{
    public class StatisticalAnalysisRepository : Repository<StatisticalAnalysisInfo>, IStatisticalAnalysisRepository
    {
        public StatisticalAnalysisRepository(BankruptContext bankruptContext, IConfiguration configuration) 
            : base(bankruptContext, configuration)
        {
        }

        public override string EntityName => "StatisticalAnalysiss";
    }
}