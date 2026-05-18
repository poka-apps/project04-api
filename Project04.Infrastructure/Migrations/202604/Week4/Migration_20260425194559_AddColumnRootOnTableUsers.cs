namespace Project04.Infrastructure.Migrations
{
    [Migration(20260425194559, description: nameof(Migration_20260425194559_AddColumnRootOnTableUsers))]
    public class Migration_20260425194559_AddColumnRootOnTableUsers : AutoReversingMigration
    {
        public override void Up() =>
            Create
                .Column("Root")
                    .OnTable("USERS")
                        .AsBoolean()
                        .NotNullable()
                        .WithDefaultValue(false);
    }
}
