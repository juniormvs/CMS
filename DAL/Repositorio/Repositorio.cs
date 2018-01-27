using Model;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace DAL
{
    public class Repositorio<T> : IRepositorio<T>, IDisposable where T : class
    {

        private Contexto _contexto;

        private DbSet<T> _entidade;

        public Repositorio()
        {
            _contexto = new Contexto();
            _contexto.Configuration.LazyLoadingEnabled = true;
            _entidade = _contexto.Set<T>();
        }

        public void Add(T entity)
        {
            _entidade.Add(entity);
        }

        public void Delete(T entity)
        {
            _contexto.Entry<T>(entity).State = EntityState.Deleted;
        }

        public T Find(Expression<Func<T, bool>> where)
        {
            return _entidade.Where(where).ToList().FirstOrDefault<T>();
        }

        public IQueryable<T> GetAll()
        {
            return _entidade;
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> where)
        {
            return _entidade.Where(where);
        }
        
        public void Update(T entity)
        {
            _contexto.Entry<T>(entity).State = EntityState.Modified;
        }

        public void SaveChanges()
        {
            _contexto.SaveChanges();
        }
        public void Dispose()
        {
            if(_contexto != null)
            {
                _contexto.Dispose();
            }
            GC.SuppressFinalize(this);
        }

       
    }
}
