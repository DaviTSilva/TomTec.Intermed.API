using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using TomTec.Intermed.Models;

namespace TomTec.Intermed.Data
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T entity);
        public void Delete(int id);
        T Get(int id);
        T Get(int id, params Expression<Func<T, object>>[] includes);
        IEnumerable<T> Get();
        IEnumerable<T> Get(params Expression<Func<T, object>>[] includes);
        IEnumerable<T> Get(Func<T, bool> query);
        IEnumerable<T> Get(Func<T, bool> query, params Expression<Func<T, object>>[] includes);
        void Update(T entity);
    }
}
