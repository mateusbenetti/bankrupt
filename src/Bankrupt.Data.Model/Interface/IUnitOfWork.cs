using System;

namespace Bankrupt.Data.Model.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}
