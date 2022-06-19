using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using TomTec.Intermed.Models;

namespace TomTec.Intermed.Data
{
    public class SQLRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly IntermedDBContext _dbContext;
        public IntermedDBContext DBContext { get { return _dbContext; } }
        public SQLRepository(IntermedDBContext userContext)
        {
            _dbContext = userContext;
            _dbContext.ChangeTracker.LazyLoadingEnabled = false;
        }

        public T Create(T entity)
        {
            entity.CreationDate = DateTime.UtcNow;
            _dbContext.Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public void Delete(int id)
        {
            _dbContext.Remove(Get(id));
            _dbContext.SaveChanges();
        }

        public T Get(int id)
        {
            return (T)_dbContext.Set<T>().FirstOrDefault(e => e.Id == id);
        }

        public T Get(int id, params Expression<Func<T, object>>[] includes)
        {
            return _dbContext.Set<T>().IncludeMultiple(includes).FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<T> Get()
        {
            return (IEnumerable<T>)_dbContext.Set<T>();
        }

        public IEnumerable<T> Get(params Expression<Func<T, object>>[] includes)
        {
            return (IEnumerable<T>)_dbContext.Set<T>().IncludeMultiple(includes);
        }


        public IEnumerable<T> Get(Func<T, bool> query)
        {
            return (IEnumerable<T>)_dbContext.Set<T>().Where(query);
        }

        public IEnumerable<T> Get(Func<T, bool> query, params Expression<Func<T, object>>[] includes)
        {
            return (IEnumerable<T>)_dbContext.Set<T>().IncludeMultiple(includes).Where(query);
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.Entry(entity).Property(x => x.CreationDate).IsModified = false;
            _dbContext.SaveChanges();
        }
    }
}
