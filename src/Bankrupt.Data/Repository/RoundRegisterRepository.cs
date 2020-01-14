using Bankrupt.Data.Context;
using Bankrupt.Data.Model.Interface;
using Bankrupt.Data.Repository;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace Bankrupt.Data.Model.Repository
{
    public class RoundRegisterRepository : Repository<RoundRegisterInfo>, IRoundRegisterRepository
    {
        public RoundRegisterRepository(BankruptContext bankruptContext, IConfiguration configuration) 
            : base(bankruptContext, configuration)
        {
        }

        public override string EntityName => "RoundRegisters";
    }
}