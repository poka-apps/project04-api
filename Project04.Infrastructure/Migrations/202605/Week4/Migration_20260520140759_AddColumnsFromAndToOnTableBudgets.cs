namespace Project04.Infrastructure.Migrations
{
    [Migration(20260520140759, description: nameof(Migration_20260520140759_AddColumnsFromAndToOnTableBudgets))]
    public class Migration_20260520140759_AddColumnsFromAndToOnTableBudgets : AutoReversingMigration
    {
        public override void Up()
        {
            Create
                .Column("From")
                    .OnTable("BUDGETS")
                        .AsDateTime()
                        .Nullable();

            Create
                .Column("To")
                    .OnTable("BUDGETS")
                        .AsDateTime()
                        .Nullable();
        }
    }
}
