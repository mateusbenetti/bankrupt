namespace Bankrupt.Data.Model.Interface
{
    public interface IStatisticalAnalysisRepository : IRepository<StatisticalAnalysisInfo>
    {
        StatisticalAnalysisInfo GetRegisterCode(string registerCode);
    }
}
