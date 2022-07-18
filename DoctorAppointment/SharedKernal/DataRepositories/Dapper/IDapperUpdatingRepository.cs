using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernal.DataRepositories.Dapper
{
    public interface IDapperUpdatingRepository<TEntity, PrimaryKey> where TEntity : class
    {
        Task<TEntity> Update(TEntity entity);
        Task<IEnumerable<TEntity>> Update(IEnumerable<TEntity> entity);

    }
}
