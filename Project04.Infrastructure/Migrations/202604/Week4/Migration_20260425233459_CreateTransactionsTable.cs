namespace Project04.Infrastructure.Migrations
{
    [Migration(20260425233459, description: nameof(Migration_20260425233459_CreateTransactionsTable))]
    public class Migration_20260425233459_CreateTransactionsTable : AutoReversingMigration
    {
        public override void Up() =>
            Create
                .Table("TRANSACTIONS")
                .WithColumn("Id")
                    .AsGuid()
                    .PrimaryKey()
                    .WithDefaultValue(RawSql.Insert("gen_random_uuid()"))
                .WithColumn("BudgetId")
                    .AsGuid()
                    .ForeignKey(
                        foreignKeyName: "FK_TRANSACTIONS_BUDGETS_BudgetId",
                        primaryTableName: "BUDGETS",
                        primaryColumnName: "Id"
                    )
                    .NotNullable()
                .WithColumn("Amount")
                    .AsFloat()
                    .NotNullable()
                .WithColumn("Title")
                    .AsString(100)
                    .NotNullable()
                .WithColumn("Description")
                    .AsString(5000)
                    .Nullable()
                .WithColumn("CreatedByUserId")
                    .AsGuid()
                    .ForeignKey(
                        foreignKeyName: "FK_TRANSACTIONS_USERS_CreatedByUserId",
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
