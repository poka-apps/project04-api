namespace Project04.Infrastructure.DbContexts.EntityTypeConfigurations
{
    internal class BudgetEntityConfiguration : IEntityTypeConfiguration<BudgetEntity>
    {
        public void Configure(EntityTypeBuilder<BudgetEntity> builder)
        {
            builder.ToTable("BUDGETS");

            builder
                .HasKey(l => l.Id);

            builder
                .Property(l => l.Id)
                .HasColumnName("Id")
                .HasConversion(
                    objValue => objValue.Value,
                    dbValue => new BudgetId(dbValue)
                )
                .HasDefaultValueSql("gen_random_uuid()");

            builder
                .Property(l => l.Title)
                .HasColumnName("Title")
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(l => l.Description)
                .HasColumnName("Description")
                .HasMaxLength(5000);

            builder
                .Property(l => l.CreatedOn)
                .HasColumnName("CreatedOn")
                .HasDefaultValueSql("NOW()")
                .IsRequired();

            builder
                .OwnsOne(
                    l => l.Period,
                    ownedNavigationBuilder =>
                    {
                        ownedNavigationBuilder
                            .Property(l => l.From)
                            .HasColumnName("From")
                            .IsRequired(false);

                        ownedNavigationBuilder
                            .Property(l => l.To)
                            .HasColumnName("To")
                            .IsRequired(false);
                    }
                );
        }
    }
}
