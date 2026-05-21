namespace Project04.Infrastructure.Migrations
{
    [Migration(20260426001159, description: nameof(Migration_20260426001159_CreateMembersTable))]
    public class Migration_20260426001159_CreateMembersTable : AutoReversingMigration
    {
        public override void Up() =>
            Create
                .Table("MEMBERS")
                .WithColumn("Id")
                    .AsGuid()
                    .PrimaryKey()
                    .WithDefaultValue(RawSql.Insert("gen_random_uuid()"))
                .WithColumn("UserId")
                    .AsGuid()
                    .ForeignKey(
                        foreignKeyName: "FK_MEMBERS_USERS_UserId",
                        primaryTableName: "USERS",
                        primaryColumnName: "Id"
                    )
                    .NotNullable()
                .WithColumn("Address.Number")
                    .AsString(10)
                    .Nullable()
                .WithColumn("Address.Street")
                    .AsString(100)
                    .Nullable()
                .WithColumn("Address.Street2")
                    .AsString(100)
                    .Nullable()
                .WithColumn("Address.City")
                    .AsString(100)
                    .Nullable()
                .WithColumn("Address.PostalCode")
                    .AsString(20)
                    .Nullable()
                .WithColumn("Address.CountryCodeISO2")
                    .AsString(2)
                    .Nullable()
                .WithColumn("Phone.CountryCodeIso2")
                    .AsString(2)
                    .Nullable()
                .WithColumn("Phone.Number")
                    .AsInt32()
                    .Nullable()
                .WithColumn("CreatedOn")
                    .AsDateTime()
                    .NotNullable()
                    .WithDefault(SystemMethods.CurrentUTCDateTime);
    }
}
