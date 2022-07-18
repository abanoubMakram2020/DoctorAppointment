
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernal.DataRepositories
{
    public interface IInsertRepository<TEntity, PrimaryKey> where TEntity : class
    {
        Task<TEntity> Insert(TEntity entity);
        Task<IEnumerable<TEntity>> Insert(IEnumerable<TEntity> entity);
    }
}
