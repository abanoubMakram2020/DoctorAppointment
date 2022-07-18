using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SharedKernal.DataRepositories
{
    public interface IRetrievingRepository<TEntity, PrimaryKey> where TEntity : class
    {
        Task<TEntity> Get(PrimaryKey id);
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> expression = null, string includes = "");

    }
}
