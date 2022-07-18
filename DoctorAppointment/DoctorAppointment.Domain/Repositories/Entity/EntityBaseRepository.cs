using Microsoft.EntityFrameworkCore;
using SharedKernal.Common;
using SharedKernal.DataRepositories;
using SharedKernal.Middlewares.Basees;
using SharedKernal.PagingModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DoctorAppointment.Domain.Repositories.Entity
{
    public class EntityBaseRepository<TEntity, TPrimaryKey> : IBaseRepository<TEntity, TPrimaryKey> where TEntity : class
    {
        public readonly DbContext _dbContext;
        public readonly DbSet<TEntity> _dbSet;

        public EntityBaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(DbContext));
            _dbSet = _dbContext.Set<TEntity>();
        }

        #region Retriveing
        public async Task<TEntity> Get(TPrimaryKey id)
        {
            var entity = await _dbSet.FindAsync(id);
            return entity;
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> expression = null, string includes = "")
        {
            IQueryable<TEntity> query = _dbSet;
            if (!string.IsNullOrWhiteSpace(includes))
                query = includes.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Aggregate(query, (current, include) => current.Include(include));

            if (expression == null)
                return query;
            else
                return query.Where(expression);
        }

        //public async Task<BaseResponsePaging<TEntity>> Get(Paging paging, Expression<Func<TEntity, bool>> expression = null, string includes = "")
        //{
        //    IQueryable<TEntity> query = _dbSet;
        //    var responsePaging = new BaseResponsePaging<TEntity>();
        //    if (!string.IsNullOrWhiteSpace(includes))
        //        query = includes.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
        //            .Aggregate(query, (current, include) => current.Include(include));

        //    responsePaging.RecordsTotal = query.Count();

        //    if (paging.Search != null)
        //        query = query.WhereContains(paging.Search.SearchColumns, paging.Search.SearchText);

        //    responsePaging.RecordsFiltered = query.Count();

        //    if (paging.OrderColumns != null && paging.OrderColumns.Count != 0)
        //        query = query.OrderBy(paging.OrderColumns);

        //    query = query.Skip((paging.PageNo - 1) * paging.PageSize).Take(paging.PageSize);

        //    responsePaging.Result = await query.ToListAsync();
        //    return responsePaging;
        //}

        //private async Task<BaseResponsePaging<TEntity>> Get(Paging paging, Expression<Func<TEntity, bool>> orderExpression = null, Expression<Func<TEntity, bool>> expression = null, string includes = "")
        //{
        //    IQueryable<TEntity> query = _dbSet;
        //    var responsePaging = new BaseResponsePaging<TEntity>();
        //    if (!string.IsNullOrWhiteSpace(includes))
        //        query = includes.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
        //            .Aggregate(query, (current, include) => current.Include(include));

        //    if (expression != null) query = query.Where(expression);
        //    if (orderExpression != null) query = query.OrderBy(orderExpression);

        //    responsePaging.RecordsFiltered = query.Count();
        //    query = query.Skip((paging.PageNo - 1) * paging.PageSize).Take(paging.PageSize);

        //    responsePaging.Result = await query.ToListAsync();
        //    return responsePaging;
        //}

        #endregion

        #region Insert
        public async Task<TEntity> Insert(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException();

            entity = (await _dbSet.AddAsync(entity)).Entity;

            return entity;
        }

        public async Task<IEnumerable<TEntity>> Insert(IEnumerable<TEntity> entity)
        {
            if (entity == null)
                throw new ArgumentNullException();

            await _dbSet.AddRangeAsync(entity);

            return entity;
        }
        #endregion

        #region Update
        public TEntity Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException();

            _dbSet.Update(entity);

            return entity;
        }

        public IEnumerable<TEntity> Update(IEnumerable<TEntity> entity)
        {
            if (entity == null)
                throw new ArgumentNullException();

            _dbSet.UpdateRange(entity);

            return entity;
        }
        #endregion

        #region Hard Delete
        public void Delete(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException();

            _dbSet.Remove(entity);
        }

        public void Delete(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException();

            _dbSet.RemoveRange(entities);
        }

        public void Delete(TPrimaryKey key)
        {
            var entity = _dbSet.Find(key);
            _dbSet.Remove(entity);
        }


        #endregion
    }
}
