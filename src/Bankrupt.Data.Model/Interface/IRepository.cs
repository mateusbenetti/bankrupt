using System;
using System.Linq;

namespace Bankrupt.Data.Model.Interface
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        TEntity GetById(Guid id);
        void Add(TEntity obj);
    }
}