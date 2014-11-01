using System;
using System.Collections.Generic;
using System.Linq;

namespace RepositoryPattern
{
 /// <summary>
/// A generic repository for working with data in the database
/// </summary>
/// <typeparam name="T">A POCO that represents an Entity Framework entity</typeparam>
public class GenericRepository : IRepository
{
    /// <summary>
    /// The context object for the database
    /// </summary>
    private ObjectContext _context;
    private readonly PluralizationService _pluralizer;
 
    /// <summary>
    /// Initializes a new instance of the GenericRepository class
    /// </summary>
    /// <param name="context">The Entity Framework ObjectContext</param>
    public GenericRepository(ObjectContext context)
    {
        _context = context;
        _pluralizer = PluralizationService.CreateService(CultureInfo.GetCultureInfo("en"));
    }
 
    public IQueryable<TEntity> GetQuery<TEntity>() where TEntity : class
    {
        var entityName = GetEntityName<TEntity>();
        return _context.CreateQuery<TEntity>(entityName);
    }
 
    public IEnumerable<TEntity> GetAll<TEntity>() where TEntity : class
    {
        return GetQuery<TEntity>().AsEnumerable();
    }
 
    public IEnumerable<TEntity> Find<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
    {
        return GetQuery<TEntity>().Where(predicate).AsEnumerable();
    }
 
    public TEntity Single<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
    {
        return GetQuery>TEntity>().Single<TEntity>(predicate);
    }
 
    public TEntity First<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
    {
        return GetQuery<TEntity>().Where(predicate).FirstOrDefault();
    }
 
    public void Add<TEntity>(TEntity entity) where TEntity : class
    {
        _context.AddObject(GetEntityName<TEntity>(), entity);
    }
 
    public void Delete<TEntity>(TEntity entity) where TEntity : class
    {
        _context.DeleteObject(entity);
    }
 
    private string GetEntityName<TEntity>() where TEntity : class
    {
        return string.Format("ObjectContext.{0}", _pluralizer.Pluralize(typeof(TEntity).Name));
    }
    // ...

    /// <summary>
    /// Releases all resources used by the WarrantManagement.DataExtract.Dal.ReportDataBase
    /// </summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this); //only when destructor is defined
    }

    /// <summary>
    /// Releases all resources used by the WarrantManagement.DataExtract.Dal.ReportDataBase
    /// </summary>
    /// <param name="disposing">A boolean value indicating whether or not to dispose managed resources</param>
    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (_context != null)
            {
                _context.Dispose();
                _context = null;
            }
        }
    }
    }
}