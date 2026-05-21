using EventId = Project04.Domain.ValueObjects.EventId;

namespace Project04.Infrastructure.DbContexts.EntityTypeConfigurations
{
    internal class EventEntityConfiguration : IEntityTypeConfiguration<EventEntity>
    {
        public void Configure(EntityTypeBuilder<EventEntity> builder)
        {
            builder.ToTable("EVENTS");

            builder
                .HasKey(l => l.Id);

            builder
                .Property(l => l.Id)
                .HasColumnName("Id")
                .HasConversion(
                    objValue => objValue.Value,
                    dbValue => new EventId(dbValue)
                )
                .HasDefaultValueSql("gen_random_uuid()");

            builder
                .Property(l => l.BudgetId)
                .HasColumnName("BudgetId")
                .HasConversion<Guid?>(
                    objValue => objValue != null 
                                    ? objValue.Value 
                                    : null,
                    dbValue => dbValue != null
                                    ? new BudgetId(dbValue.Value)
                                    : null
                )
                .IsRequired(false);

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
                .Property(l => l.On)
                .HasColumnName("On")
                .IsRequired();

            builder
                .Property(l => l.CreatedByUserId)
                .HasColumnName("CreatedByUserId")
                .HasConversion<Guid?>(
                    objValue => objValue == null
                                    ? null
                                    : objValue.Value,
                    dbValue => dbValue == null
                                    ? null
                                    : new UserId(dbValue.Value)
                );

            builder
                .Property(l => l.CreatedOn)
                .HasColumnName("CreatedOn")
                .HasDefaultValueSql("NOW()")
                .IsRequired();
        }
    }
}
