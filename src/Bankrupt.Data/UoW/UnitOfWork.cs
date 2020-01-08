using Bankrupt.Data.Context;
using Bankrupt.Data.Model.Interface;
using System;

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

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
