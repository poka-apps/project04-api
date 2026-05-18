namespace Project04.Infrastructure.Migrations
{
    [Migration(20260425192859, description: nameof(Migration_20260425192859_AddColumnsPasswordOnTableUsers))]
    public class Migration_20260425192859_AddColumnsPasswordOnTableUsers : AutoReversingMigration
    {
        public override void Up()
        {
            Create
                .Column("PasswordHash")
                    .OnTable("USERS")
                        .AsBinary(int.MaxValue)
                        .Nullable();

            Create
                .Column("PasswordSalt")
                    .OnTable("USERS")
                        .AsBinary(int.MaxValue)
                        .Nullable();
        }
    }
}
