using System;
using System.Threading.Tasks;

namespace Bankrupt.Data.Model.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
        Task<bool> CommitAsync();
    }
}
