using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernal.DataRepositories
{
    public interface IUpdatingRepository<TEntity, PrimaryKey> where TEntity : class
    {
        TEntity Update(TEntity entity);
        IEnumerable<TEntity> Update(IEnumerable<TEntity> entity);

    }
}
