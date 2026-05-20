namespace Project04.Infrastructure.DbContexts.EntityTypeConfigurations
{
    internal class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("USERS");

            builder
                .HasKey(l => l.Id);

            builder
                .Property(l => l.Id)
                .HasColumnName("Id")
                .HasConversion(
                    objValue => objValue.Value,
                    dbValue => new UserId(dbValue)
                )
                .HasDefaultValueSql("gen_random_uuid()");

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
                .Property(l => l.Firstname)
                .HasColumnName("FirstName")
                .HasConversion(
                    objValue => objValue.Value,
                    dbValue => new Name(dbValue)
                );

            builder
                .Property(l => l.Lastname)
                .HasColumnName("LastName")
                .HasConversion(
                    objValue => (
                        objValue == null
                            ? null
                            : objValue.Value
                    ),
                    dbValue => (
                        dbValue == null
                            ? null
                            : new Name(dbValue)
                    )
                );

            builder
                .Property(l => l.Email)
                .HasColumnName("Email")
                .HasConversion(
                    objValue => (
                        objValue == null
                            ? null
                            : objValue.Value
                    ),
                    dbValue => (
                        dbValue == null
                            ? null
                            : new Email(dbValue)
                    )
                );

            builder
                .Property(l => l.CreatedOn)
                .HasColumnName("CreatedOn")
                .HasDefaultValueSql("NOW()")
                .IsRequired();

            builder
                .OwnsOne(
                    l => l.Password, 
                    ownedNavigationBuilder =>
                    {
                        ownedNavigationBuilder
                            .Property(l => l.Hash)
                            .HasColumnName("PasswordHash")
                            .IsRequired(false);

                        ownedNavigationBuilder
                            .Property(l => l.Salt)
                            .HasColumnName("PasswordSalt")
                            .IsRequired(false);
                    }
                );

            builder
                .Property(p => p.Root)
                .HasColumnName("Root")
                .HasDefaultValue(false);

            builder
                .Property(l => l.Role)
                .HasColumnName("Role")
                .HasConversion(
                    objValue => objValue.Name,
                    dbValue => UserRoleEnums.FromValue(dbValue)
                );
        }
    }
}
