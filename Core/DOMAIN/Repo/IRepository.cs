using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Budget.Core
{
    public interface IRepository <T> where T:class
    {
         IQueryable<T> AsQueryable();
        IEnumerable<T> All();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        T Get(Expression<Func<T, bool>> predicate);
        T GetById(Guid id);

        void Add(T entity);
        void Modify(T entity);
        void Remove(T entity);

        void Save();
        void Dispose();
    }
}