namespace Project04.Infrastructure.Migrations
{
    [Migration(20260425230859, description: nameof(Migration_20260425230859_CreateBudgetsTable))]
    public class Migration_20260425230859_CreateBudgetsTable : AutoReversingMigration
    {
        public override void Up() =>
            Create
                .Table("BUDGETS")
                .WithColumn("MemberId")
                    .AsGuid()
                    .PrimaryKey()
                    .WithDefaultValue(RawSql.Insert("gen_random_uuid()"))
                .WithColumn("Title")
                    .AsString(100)
                    .Unique()
                    .NotNullable()
                .WithColumn("Description")
                    .AsString(5000)
                    .Nullable()
                .WithColumn("CreatedOn")
                    .AsDateTime()
                    .NotNullable()
                    .WithDefault(SystemMethods.CurrentUTCDateTime);
    }
}
