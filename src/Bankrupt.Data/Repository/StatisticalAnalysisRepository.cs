using Bankrupt.Data.Context;
using Bankrupt.Data.Model.Interface;
using Bankrupt.Data.Repository;
using Dapper;
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

        public StatisticalAnalysisInfo GetRegisterCode(string registerCode)
        {
            var statisticalAnalysisInfo = new StatisticalAnalysisInfo();
            var parameters = new DynamicParameters();
            parameters.Add("@RegisterCode", registerCode);
            statisticalAnalysisInfo = GetFirstOrDefault("SELECT * FROM StatisticalAnalysis WHERE RegisterCode = @RegisterCode", parameters) ?? new StatisticalAnalysisInfo();
            return statisticalAnalysisInfo;
        }
    }
}