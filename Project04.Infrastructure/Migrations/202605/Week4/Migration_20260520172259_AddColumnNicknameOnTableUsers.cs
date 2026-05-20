namespace Project04.Infrastructure.Migrations
{
    [Migration(20260520172259, description: nameof(Migration_20260520172259_AddColumnNicknameOnTableUsers))]
    public class Migration_20260520172259_AddColumnNicknameOnTableUsers : AutoReversingMigration
    {
        public override void Up()
        {
            Create
                .Column("Nickname")
                    .OnTable("USERS")
                        .AsString(100)
                        .Nullable();
        }
    }
}
