namespace Project04.Infrastructure.Migrations
{
    [Migration(20260426001159, description: nameof(Migration_20260426001159_CreateMembersTable))]
    public class Migration_20260426001159_CreateMembersTable : AutoReversingMigration
    {
        public override void Up() =>
            Create
                .Table("MEMBERS")
                .WithColumn("MemberId")
                    .AsGuid()
                    .PrimaryKey()
                    .WithDefaultValue(RawSql.Insert("gen_random_uuid()"))
                .WithColumn("UserId")
                    .AsGuid()
                    .ForeignKey(
                        foreignKeyName: "FK_MEMBERS_USERS_UserId",
                        primaryTableName: "USERS",
                        primaryColumnName: "MemberId"
                    )
                    .NotNullable()
                .WithColumn("CreatedOn")
                    .AsDateTime()
                    .NotNullable()
                    .WithDefault(SystemMethods.CurrentUTCDateTime);
    }
}
