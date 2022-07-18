using System.Data;
using System.Threading.Tasks;

namespace SharedKernal.DataRepositories
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// SaveChanges for one entity
        /// </summary>
        Task Commit();

        /// <summary>
        /// Commit change in database use transactionScope
        /// </summary>
        /// <returns></returns>
        Task CommitTransaction();

        /// <summary>
        /// start transaction scpe in db
        /// </summary>
        /// <returns></returns>
        Task BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Serializable);
    }
}
