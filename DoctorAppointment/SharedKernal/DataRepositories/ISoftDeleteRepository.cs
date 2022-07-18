using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernal.DataRepositories
{
    public interface ISoftDeleteRepository<TEntity, PrimaryKey> where TEntity : class
    {
        void SoftDelete(TEntity entity);
        void SoftDelete(IEnumerable<TEntity> entities);
        void SoftDelete(PrimaryKey key);
    }
}
