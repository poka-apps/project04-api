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
                .WithColumn("Email")
                    .AsString(255)
                    .Nullable()
                .WithColumn("FirstName")
                    .AsString(100)
                    .Nullable()
                .WithColumn("LastName")
                    .AsString(100)
                    .Nullable()
                .WithColumn("CreatedOn")
                    .AsDateTime()
                    .NotNullable()
                    .WithDefault(SystemMethods.CurrentUTCDateTime);
    }
}
