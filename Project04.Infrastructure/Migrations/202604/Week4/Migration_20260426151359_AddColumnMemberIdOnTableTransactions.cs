namespace Project04.Infrastructure.Migrations
{
    [Migration(20260426151359, description: nameof(Migration_20260426151359_AddColumnMemberIdOnTableTransactions))]
    public class Migration_20260426151359_AddColumnMemberIdOnTableTransactions : AutoReversingMigration
    {
        public override void Up() =>
            Create
                .Column("MemberId")
                    .OnTable("TRANSACTIONS")
                        .AsGuid()
                        .Nullable()
                        .ForeignKey(
                            foreignKeyName: "FK_TRANSACTIONS_MEMBERS_MemberId",
                            primaryTableName: "MEMBERS",
                            primaryColumnName: "Id"
                        );
    }
}
