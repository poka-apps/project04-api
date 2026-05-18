namespace Project04.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task RollbackTransactionAsync(CancellationToken cancellationToken = default);
        void RollbackTransaction();
        Task CommitTransactionAsync(CancellationToken cancellationToken = default);
        void CommitTransaction();
        Task BeginTransactionAsync(CancellationToken cancellationToken = default);
        void BeginTransaction();
    }
}
