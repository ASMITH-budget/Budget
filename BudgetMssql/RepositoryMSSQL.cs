using System.Data;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using Budget.Core;


namespace Budget.Mssql
{
    public class RepositoryMSSQL <T> : IRepository<T> where T : class
    {
      
        private readonly DbContext _context;
        public RepositoryMSSQL()
        {
            _context = new AppDbContext();

            // Load navigation properties explicitly (avoid serialization trouble)
           // _context.Configuration.LazyLoadingEnabled = false;

            // Do NOT enable proxied entities, else serialization fails.
           // _context.Configuration.ProxyCreationEnabled = false;

            // Because Web API will perform validation, we don't need/want EF to do so
            //_context.Configuration.ValidateOnSaveEnabled = false;
        }

        public void Add(T entity)
        {
            //if (_context.Entry<T>(entity).State != System.Data.Entity.EntityState.Detached)
            //    _context.Entry<T>(entity).State = System.Data.Entity.EntityState.Added;
            //else
                _context.Set<T>().Add(entity);
        }

        public IEnumerable<T> All()
        {
            return _context.Set<T>();
        }

        public IQueryable<T> AsQueryable()
        {
            return _context.Set<T>().AsQueryable();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate).FirstOrDefault();
        }

        public T GetById(Guid id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Modify(T entity)
        {
            //First Approach
            //if (_context.Entry<T>(entity).State == System.Data.Entity.EntityState.Detached)
            //    _context.Set<T>().Attach(entity);
            //_context.Entry<T>(entity).State = System.Data.Entity.EntityState.Modified;
           _context.Set<T>().Update(entity);
        }

        public void Remove(T entity)
        {
            //if (_context.Entry(entity).State  == System.Data.Entity.EntityState.Detached)
            //    _context.Set<T>().Attach(entity);
            //_context.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
            _context.Set<T>().Remove(entity);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
