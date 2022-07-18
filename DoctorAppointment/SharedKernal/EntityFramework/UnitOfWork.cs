using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SharedKernal.DataRepositories;
using System.Data;


namespace SharedKernal.EntityFramework
{
    public partial class UnitOfWork : IUnitOfWork, IDisposable
    {

        #region Field
        private readonly DbContext context;
        private IDbContextTransaction dbContextTransaction;

        #endregion

        #region Cto
        public UnitOfWork(DbContext context)
        {
            this.context = context;
        }
        #endregion

        public async Task BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Serializable)
        {
            dbContextTransaction = await context.Database.BeginTransactionAsync(isolationLevel: isolationLevel);

        }

        public async Task Commit()
        {
            //SetAudit();
            await context.SaveChangesAsync();
        }

        public async Task CommitTransaction()
        {

            try
            {
                //SetAudit();
                await Commit();
                await dbContextTransaction.CommitAsync();
            }
            catch (Exception exception)
            {
                await RollbackTransaction();
                throw;
            }
        }

        public virtual void Dispose()
        {
            context.Dispose();
            if (dbContextTransaction != null)
                dbContextTransaction.Dispose();
        }

        private async Task RollbackTransaction()
        {
            await dbContextTransaction.RollbackAsync();
        }
    }
}
