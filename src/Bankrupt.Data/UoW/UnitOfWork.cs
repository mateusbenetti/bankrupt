using Bankrupt.Data.Context;
using Bankrupt.Data.Model.Interface;
using System;
using System.Threading.Tasks;

namespace Bankrupt.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BankruptContext _bankruptContext;
        public UnitOfWork(BankruptContext bankruptContext)
        {
            _bankruptContext = bankruptContext;
        }
        public bool Commit()
        {
            return _bankruptContext.SaveChanges() > 0;
        }
        async Task<bool> IUnitOfWork.CommitAsync()
        {
            var result = await _bankruptContext.SaveChangesAsync() > 0;
            return result;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
