namespace Project04.Infrastructure.DbContexts.EntityTypeConfigurations
{
    internal class MemberEntityConfiguration : IEntityTypeConfiguration<MemberEntity>
    {
        public void Configure(EntityTypeBuilder<MemberEntity> builder)
        {
            builder.ToTable("MEMBERS");

            builder
                .HasKey(l => l.Id);

            builder
                .Property(l => l.Id)
                .HasColumnName("Id")
                .HasConversion(
                    objValue => objValue.Value,
                    dbValue => new MemberId(dbValue)
                )
                .HasDefaultValueSql("gen_random_uuid()");

            builder
                .Property(l => l.UserId)
                .HasColumnName("UserId")
                .HasConversion(
                    objValue => objValue.Value,
                    dbValue => new UserId(dbValue)
                )
                .IsRequired();

            builder
                .Property(l => l.CreatedOn)
                .HasColumnName("CreatedOn")
                .HasDefaultValueSql("NOW()")
                .IsRequired();

            builder
                .OwnsOne(
                    l => l.Address,
                    ownedNavigationBuilder =>
                    {
                        ownedNavigationBuilder
                            .Property(l => l.Street)
                            .HasColumnName("Street")
                            .IsRequired(true);

                        ownedNavigationBuilder
                            .Property(l => l.Street2)
                            .HasColumnName("Street2")
                            .IsRequired(false);

                        ownedNavigationBuilder
                            .Property(l => l.City)
                            .HasColumnName("City")
                            .IsRequired(true);

                        ownedNavigationBuilder
                            .Property(l => l.PostalCode)
                            .HasColumnName("PostalCode")
                            .IsRequired(true);

                        ownedNavigationBuilder
                            .Property(l => l.CountryCodeISO2)
                            .HasColumnName("CountryCodeISO2")
                            .IsRequired(true);
                    }
                );
        }
    }
}
