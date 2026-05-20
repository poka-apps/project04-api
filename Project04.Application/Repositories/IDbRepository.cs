namespace Project04.Application.Repositories
{
    public interface IDbRepository : IUnitOfWork
    {
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
        void SaveChanges();
        DbSet<TransactionEntity> Transactions { get; }
        DbSet<BudgetEntity> Budgets { get; }
        DbSet<MemberEntity> Members { get; }
        DbSet<EventEntity> Events { get; }
        DbSet<UserEntity> Users { get; }
    }
}
