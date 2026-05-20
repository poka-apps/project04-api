namespace Project04.Infrastructure.DbContexts.EntityTypeConfigurations
{
    internal class TransactionEntityConfiguration : IEntityTypeConfiguration<TransactionEntity>
    {
        public void Configure(EntityTypeBuilder<TransactionEntity> builder)
        {
            builder.ToTable("TRANSACTIONS");

            builder
                .HasKey(l => l.Id);

            builder
                .Property(l => l.Id)
                .HasColumnName("Id")
                .HasConversion(
                    objValue => objValue.Value,
                    dbValue => new TransactionId(dbValue)
                )
                .HasDefaultValueSql("gen_random_uuid()");

            builder
                .Property(l => l.BudgetId)
                .HasColumnName("BudgetId")
                .HasConversion(
                    objValue => objValue.Value,
                    dbValue => new BudgetId(dbValue)
                );

            builder
                .Property(l => l.MemberId)
                .HasColumnName("MemberId")
                .HasConversion<Guid?>(
                    objValue =>   objValue == null
                                    ? null
                                    : objValue.Value,
                    dbValue =>  dbValue == null
                                    ? null
                                    : new MemberId(dbValue.Value)
                );

            builder
                .Property(l => l.Amount)
                .HasColumnName("Amount")
                .IsRequired();

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
        }
    }
}
