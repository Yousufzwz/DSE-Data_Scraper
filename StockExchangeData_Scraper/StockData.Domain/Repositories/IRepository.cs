﻿using StockData.Domain.Entities;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using StockData.Domain.Repositories;

namespace StockData.Domain.Repositories
{
    public interface IRepository<TEntity, TKey> : IRepositoryBase<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
        where TKey : IComparable
    {
        IList<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, bool isTrackingOff = false);
        (IList<TEntity> data, int total, int totalDisplay) Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, int pageIndex = 1, int pageSize = 10, bool isTrackingOff = false);
        IList<TEntity> Get(Expression<Func<TEntity, bool>> filter, string includeProperties = "", Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);
        Task<IList<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, bool isTrackingOff = false);
        Task<(IList<TEntity> data, int total, int totalDisplay)> GetAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, int pageIndex = 1, int pageSize = 10, bool isTrackingOff = false);
        Task<IList<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);
        Task<IEnumerable<TResult>> GetAsync<TResult>(Expression<Func<TEntity, TResult>> selector, Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, bool disableTracking = true, CancellationToken cancellationToken = default) where TResult : class;
        IList<TEntity> GetDynamic(Expression<Func<TEntity, bool>> filter = null, string orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, bool isTrackingOff = false);
        (IList<TEntity> data, int total, int totalDisplay) GetDynamic(Expression<Func<TEntity, bool>> filter = null, string orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, int pageIndex = 1, int pageSize = 10, bool isTrackingOff = false);
        Task<IList<TEntity>> GetDynamicAsync(Expression<Func<TEntity, bool>> filter = null, string orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, bool isTrackingOff = false);
        Task<(IList<TEntity> data, int total, int totalDisplay)> GetDynamicAsync(Expression<Func<TEntity, bool>> filter = null, string orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, int pageIndex = 1, int pageSize = 10, bool isTrackingOff = false);
        Task<TResult> SingleOrDefaultAsync<TResult>(Expression<Func<TEntity, TResult>> selector, Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, bool disableTracking = true);
    }
}
