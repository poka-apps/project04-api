namespace Project04.Infrastructure.Migrations
{
    [Migration(20260520141759, description: nameof(Migration_20260520141759_CreateTableEvents))]
    public class Migration_20260520141759_CreateTableEvents : AutoReversingMigration
    {
        public override void Up() =>
            Create
                .Table("EVENTS")
                .WithColumn("Id")
                    .AsGuid()
                    .PrimaryKey()
                    .WithDefaultValue(RawSql.Insert("gen_random_uuid()"))
                .WithColumn("BudgetId")
                    .AsGuid()
                    .ForeignKey(
                        foreignKeyName: "FK_EVENTS_BUDGETS_BudgetId",
                        primaryTableName: "BUDGETS",
                        primaryColumnName: "Id"
                    )
                    .Nullable()
                .WithColumn("Title")
                    .AsString(100)
                    .Unique()
                    .NotNullable()
                .WithColumn("Description")
                    .AsString(5000)
                    .Nullable()
                .WithColumn("On")
                    .AsDateTime()
                    .NotNullable()
                .WithColumn("CreatedByUserId")
                    .AsGuid()
                    .ForeignKey(
                        foreignKeyName: "FK_EVENTS_USERS_CreatedByUserId",
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
