using System;
using System.Linq;
using System.Linq.Expressions;

namespace DAL
{
    public interface IRepositorio<T> where T : class
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        T Find(Expression<Func<T, bool>> where);
        IQueryable<T> GetAll();
        IQueryable<T> Get(Expression<Func<T, bool>> where);
        void SaveChanges();
        void Dispose();
    }
}
