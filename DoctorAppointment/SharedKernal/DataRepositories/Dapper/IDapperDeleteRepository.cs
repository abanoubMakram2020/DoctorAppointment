using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernal.DataRepositories.Dapper
{
    public interface IDapperDeleteRepository<TEntity, PrimaryKey> where TEntity : class
    {
        void Delete(IEnumerable<TEntity> entities);
        void Delete(PrimaryKey id);
    }
}
