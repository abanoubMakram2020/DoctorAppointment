using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernal.DataRepositories.Dapper
{
    public interface IDapperBaseRepository<TEntity, PrimaryKey> : IDapperInsertRepository<TEntity, PrimaryKey>,
                                                                  IDapperUpdatingRepository<TEntity, PrimaryKey>,
                                                                  IDapperDeleteRepository<TEntity, PrimaryKey>,
                                                                  IDapperRetrievingRepository<TEntity, PrimaryKey>
                                                                  where TEntity : class
    {

    }
}
