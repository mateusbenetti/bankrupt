using Bankrupt.Data.Context;
using Bankrupt.Data.Model.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Bankrupt.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly BankruptContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(BankruptContext db)
        {
            Db = db;
            DbSet = Db.Set<TEntity>();
        }
        public virtual IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public TEntity GetById(Guid id)
        {
            return DbSet.Find(id);
        }
    }
}
