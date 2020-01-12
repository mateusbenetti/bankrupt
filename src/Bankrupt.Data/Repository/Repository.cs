using Bankrupt.Data.Context;
using Bankrupt.Data.Model.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

namespace Bankrupt.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        IConfiguration _configuration;
        protected readonly BankruptContext Db;
        protected readonly DbSet<TEntity> DbSet;
        public abstract string EntityName { get; }
        public Repository(BankruptContext db, IConfiguration configuration)
        {
            _configuration = configuration;
            Db = db;
            DbSet = Db.Set<TEntity>();
        }

        public string GetConnection()
        {
            var connection = _configuration
                .GetSection("ConnectionStrings")
                .GetSection("DefaultConnection")
                .Value;
            return connection;
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }
        public void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }
        public TEntity GetById(Guid id)
        {
            var entity = new TEntity();
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            entity = GetFirstOrDefault("SELECT * FROM " + EntityName + "  WHERE Id = @Id", parameters) ?? new TEntity();
            return entity;
        }
        public TEntity GetFirstOrDefault(string query, DynamicParameters parameters = null)
        {
            TEntity entity;
            using (IDbConnection db = new SqlConnection(GetConnection()))
            {
                db.Open();
                try
                {
                    entity = db.QueryFirstOrDefault<TEntity>(query, parameters);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    db.Close();
                }
            }
            return entity;
        }
        public IEnumerable<TEntity> GetCollection(string query, SqlParameter[] parameters = null)
        {
            IEnumerable<TEntity> entities;
            using (IDbConnection db = new SqlConnection(GetConnection()))
            {
                db.Open();
                try
                {
                    entities = db.Query<TEntity>(query, parameters);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    db.Close();
                }
            }
            return entities;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}