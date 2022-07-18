using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernal.DataRepositories
{
    public interface IGetWithNoFiltersRepository<TEntity, PrimaryKey> where TEntity : class
    {
        TEntity GetWithNoFilters(PrimaryKey id);

        IQueryable<TEntity> GetWithNoFilters();
    }
}
