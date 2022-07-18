using Dapper;
using SharedKernal.Common.Configuration;
using SharedKernal.DataRepositories.Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorAppointment.Domain.Repositories.Dapper
{
    public class DapperBaseRepository<TEntity, TPrimaryKey> : IDapperBaseRepository<TEntity, TPrimaryKey>
                                                              where TEntity : class
    {

        #region Declarations
        public readonly string ConnectionString = string.Empty;
        #endregion

        #region Conistructors
        public DapperBaseRepository()
        {
            ConnectionString = DatabaseConfiguration.ConnectionString;
        }

        #endregion

        #region Delete

        public void Delete(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException();

            string ids = string.Empty;
            List<TPrimaryKey> idsList = new List<TPrimaryKey>();
            foreach (var entity in entities)
                idsList.Add((TPrimaryKey)entity.GetType().GetProperty("Id").GetValue(entity));

            ids = string.Join(",", idsList);

            string sql = $"delete from {(typeof(TEntity)).Name.ToLower()} where Id in ({ids})";
            using (IDbConnection dbContext = new SqlConnection(connectionString: ConnectionString))
                dbContext.Execute(sql);

        }

        public void Delete(TPrimaryKey id)
        {
            string sql = $"delete from {(typeof(TEntity)).Name.ToLower()} where Id = @id";
            using (IDbConnection dbContext = new SqlConnection(connectionString: ConnectionString))
                dbContext.Execute(sql, new { id });
        }
        #endregion

        #region Retrieving
        public async Task<TEntity> Get(TPrimaryKey id)
        {
            string sql = $"select * from {(typeof(TEntity)).Name.ToLower()} where Id = @id";
            using (IDbConnection dbContext = new SqlConnection(connectionString: ConnectionString))
            {
                return (await dbContext.QueryAsync<TEntity>(sql, new { id })).SingleOrDefault();
            }
        }

        public async Task<IEnumerable<TEntity>> Get(IDictionary<string, object> expression = null, string includes = "")
        {
            string sql = $"select * from {(typeof(TEntity)).Name.ToLower()}";
            string _whereExpression = string.Empty;
            List<string> whereExpression = new List<string>();
            var parameters = new DynamicParameters();

            if (expression != null && expression.Any())
                foreach (var item in expression)
                {
                    whereExpression.Add(string.Concat(item.Key, " = :", item.Key));
                    parameters.Add(name: item.Key, value: item.Value);
                }

            if (whereExpression.Any() && whereExpression.Count() > default(int))
                _whereExpression = string.Join(" and ", whereExpression);

            using (IDbConnection dbContext = new SqlConnection(connectionString: ConnectionString))
            {
                if (!string.IsNullOrWhiteSpace(_whereExpression))
                    return (await dbContext.QueryAsync<TEntity>($"{sql} where {_whereExpression} ", parameters)).ToList();
                else
                    return (await dbContext.QueryAsync<TEntity>(sql)).ToList();
            }
        }
        #endregion

        #region Insert
        public async Task<TEntity> Insert(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException();

            TPrimaryKey id = default(TPrimaryKey);

            List<string> coll = new List<string>();
            List<string> collValues = new List<string>();

            foreach (var property in entity.GetType().GetProperties())
                if (!property.Name.Equals("Id"))
                {
                    coll.Add($"[{property.Name}]");
                    collValues.Add($"@{property.Name}");
                }

            string sql = $"INSERT INTO {(typeof(TEntity)).Name.ToLower()} ({string.Join(", ", coll)} ) values({string.Join(", ", collValues)}); SELECT CAST(SCOPE_IDENTITY() as {nameof(TPrimaryKey)})";

            using (IDbConnection dbContext = new SqlConnection(connectionString: ConnectionString))
            {
                id = await dbContext.ExecuteScalarAsync<TPrimaryKey>(sql, entity);
                entity.GetType().GetProperty("Id").SetValue(entity, (TPrimaryKey)id);
                return entity;
            }
        }

        public Task<IEnumerable<TEntity>> Insert(IEnumerable<TEntity> entity)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Update
        public async Task<TEntity> Update(TEntity entity)
        {

            if (entity == null)
                throw new ArgumentNullException();

            string _tbl = string.Empty;
            List<string> _tblColl = new List<string>();

            foreach (var property in entity.GetType().GetProperties())
                if (!property.Name.Equals("Id"))
                    _tblColl.Add(string.Concat(property.Name, " = @", property.Name));

            if (_tblColl.Count > default(int))
                _tbl = string.Join(", ", _tblColl);

            using (IDbConnection dbContext = new SqlConnection(connectionString: ConnectionString))
            {
                await dbContext.ExecuteAsync($"update {(typeof(TEntity)).Name.ToLower()} set {_tbl} where Id = @id", param: entity);
                return entity;
            }
        }

        public async Task<IEnumerable<TEntity>> Update(IEnumerable<TEntity> entity)
        {
            if (entity == null)
                throw new ArgumentNullException();

            string _tbl = string.Empty;
            List<string> _tblColl = new List<string>();

            foreach (var property in entity.FirstOrDefault().GetType().GetProperties())
                if (!property.Name.Equals("Id"))
                    _tblColl.Add(string.Concat(property.Name, " = @", property.Name));

            if (_tblColl.Count > default(int))
                _tbl = string.Join(", ", _tblColl);

            using (IDbConnection dbContext = new SqlConnection(connectionString: ConnectionString))
            {
                foreach (var item in entity)
                    await dbContext.ExecuteAsync($"update {(typeof(TEntity)).Name.ToLower()} set {_tbl} where Id = @id", param: item);
                return entity;
            }
        }
        #endregion
    }
}
