namespace Project04.Infrastructure.Migrations
{
    [Migration(20260426001359, description: nameof(Migration_20260426001359_AddColumnMemberIdOnTableUsers))]
    public class Migration_20260426001359_AddColumnMemberIdOnTableUsers : AutoReversingMigration
    {
        public override void Up() =>
            Create
                .Column("MemberId")
                    .OnTable("USERS")
                        .AsGuid()
                        .Nullable()
                        .ForeignKey(
                            foreignKeyName: "FK_USERS_MEMBERS_MemberId",
                            primaryTableName: "MEMBERS",
                            primaryColumnName: "MemberId"
                        );
    }
}
