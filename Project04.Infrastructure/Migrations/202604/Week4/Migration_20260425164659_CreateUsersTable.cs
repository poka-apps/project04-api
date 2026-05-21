namespace Project04.Infrastructure.Migrations
{
    [Migration(20240101000000, description: nameof(Migration_20260425164659_CreateUsersTable))]
    public class Migration_20260425164659_CreateUsersTable : AutoReversingMigration
    {
        public override void Up() =>
            Create
                .Table("USERS")
                .WithColumn("Id")
                    .AsGuid()
                    .PrimaryKey()
                    .WithDefaultValue(RawSql.Insert("gen_random_uuid()"))
                .WithColumn("Role")
                    .AsString(100)
                    .NotNullable()
                    .WithDefaultValue(UserRoleEnums.User.Name)
                .WithColumn("Email")
                    .AsString(255)
                    .Nullable()
                .WithColumn("Firstname")
                    .AsString(100)
                    .Nullable()
                .WithColumn("Lastname")
                    .AsString(100)
                    .NotNullable()
                    .Unique()
                .WithColumn("Nickname")
                    .AsString(100)
                    .Nullable()
                .WithColumn("PasswordHash")
                    .AsBinary(int.MaxValue)
                    .Nullable()
                .WithColumn("PasswordSalt")
                    .AsBinary(int.MaxValue)
                    .Nullable()
                .WithColumn("CreatedByUserId")
                    .AsGuid()
                    .ForeignKey(
                        foreignKeyName: "FK_USERS_USERS_CreatedByUserId",
                        primaryTableName: "USERS",
                        primaryColumnName: "Id"
                    )
                    .Nullable()
                .WithColumn("CreatedOn")
                    .AsDateTime()
                    .NotNullable()
                    .WithDefault(SystemMethods.CurrentUTCDateTime);
    }
}
