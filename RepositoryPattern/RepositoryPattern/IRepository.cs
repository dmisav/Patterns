using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Xml.Linq;

namespace RepositoryPattern
{
    public interface IRepository : IDisposable
    {
        IQueryable<TEntity> GetQuery<TEntity>() where TEntity : class;
        IEnumerable<TEntity> GetAll<TEntity>() where TEntity : class;
        IEnumerable<TEntity> Find<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;
        TEntity Single<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;
        TEntity First<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;
        void Add<TEntity>(TEntity entity) where TEntity : class;
        void Delete<TEntity>(TEntity entity) where TEntity : class;
        void Attach<TEntity>(TEntity entity) where TEntity : class;
        void SaveChanges();
        void SaveChanges(SaveOptions options);
    }
}