using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernal.DataRepositories
{
    public interface IDeleteRepository<TEntity, PrimaryKey> where TEntity : class
    {
        void Delete(TEntity entity);
        void Delete(IEnumerable<TEntity> entities);
        void Delete(PrimaryKey key);
    }
}
