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

            builder
                .OwnsOne(
                    l => l.Address,
                    ownedNavigationBuilder =>
                    {
                        ownedNavigationBuilder
                            .Property(l => l.Number)
                            .HasColumnName("Address.Number");

                        ownedNavigationBuilder
                            .Property(l => l.Street)
                            .HasColumnName("Address.Street");

                        ownedNavigationBuilder
                            .Property(l => l.Street2)
                            .HasColumnName("Address.Street2");

                        ownedNavigationBuilder
                            .Property(l => l.City)
                            .HasColumnName("Address.City");

                        ownedNavigationBuilder
                            .Property(l => l.PostalCode)
                            .HasColumnName("Address.PostalCode");

                        ownedNavigationBuilder
                            .Property(l => l.CountryCodeISO2)
                            .HasColumnName("Address.CountryCodeISO2");
                    }
                );

            builder
                .OwnsOne(
                    l => l.Phone,
                    ownedNavigationBuilder =>
                    {
                        ownedNavigationBuilder
                            .Property(l => l.CountryCodeIso2)
                            .HasColumnName("Phone.CountryCodeIso2");

                        ownedNavigationBuilder
                            .Property(l => l.Number)
                            .HasColumnName("Phone.Number");
                    }
                );
        }
    }
}
