using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernal.DataRepositories.Dapper
{
    public interface IDapperRetrievingRepository<TEntity, PrimaryKey> where TEntity : class
    {
        Task<TEntity> Get(PrimaryKey id);
        Task<IEnumerable<TEntity>> Get(IDictionary<string, object> expression = null, string includes = "");
    }
}
