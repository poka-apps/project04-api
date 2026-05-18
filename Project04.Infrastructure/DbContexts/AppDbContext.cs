namespace Project04.Infrastructure.DbContexts
{
    internal class AppDbContext : DbContext
    {
        public DbSet<TransactionEntity> Transactions => this.Set<TransactionEntity>();

        public DbSet<MemberEntity> Members => this.Set<MemberEntity>();

        public DbSet<BudgetEntity> Budgets => this.Set<BudgetEntity>();

        public DbSet<UserEntity> Users => this.Set<UserEntity>();

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) =>
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
