using Microsoft.EntityFrameworkCore.Storage;
using Project04.Infrastructure.DbContexts;

namespace Project04.Infrastructure.Repositories
{
    internal class DbRepository : AppDbContext, IDbRepository
    {
        private IDbContextTransaction? _dbContextTransaction;
        private ushort _dbContextTransactionHandledCount;

        public DbRepository(DbContextOptions<AppDbContext> options) 
            : base(options) 
        { }

        public new async Task SaveChangesAsync(CancellationToken cancellationToken = default) =>
            await base.SaveChangesAsync(cancellationToken);

        public new void SaveChanges() =>
            base.SaveChanges();

        public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
        {
            if (this._dbContextTransaction is null || this._dbContextTransaction.TransactionId == default)
            {
                return;
            }
            await this._dbContextTransaction.RollbackAsync(cancellationToken);

            this._dbContextTransaction = null;
            this._dbContextTransactionHandledCount = 0;
        }

        public void RollbackTransaction() =>
            this.RollbackTransactionAsync()
                .Wait();

        public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
        {
            if (this._dbContextTransaction is null || this._dbContextTransaction.TransactionId == default)
            {
                return;
            }

            this._dbContextTransactionHandledCount--;

            if (this._dbContextTransactionHandledCount == 0)
            {
                await this._dbContextTransaction.CommitAsync(cancellationToken);

                this._dbContextTransaction = null;
            }
        }

        public void CommitTransaction() =>
            this.CommitTransactionAsync()
                .Wait();

        public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            this._dbContextTransactionHandledCount++;

            if (this._dbContextTransaction is not null && this._dbContextTransaction.TransactionId != default)
            {
                return;
            }

            this._dbContextTransaction = await this.Database.BeginTransactionAsync(cancellationToken);
        }

        public void BeginTransaction() =>
            this.BeginTransactionAsync()
                .Wait();
    }
}
