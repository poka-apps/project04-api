namespace Project04.Infrastructure.Migrations
{
    [Migration(20260425235159, description: nameof(Migration_20260425235159_AddColumnRoleOnTableUsers))]
    public class Migration_20260425235159_AddColumnRoleOnTableUsers : AutoReversingMigration
    {
        public override void Up() =>
            Create
                .Column("Role")
                    .OnTable("USERS")
                        .AsString(100)
                        .NotNullable()
                        .WithDefaultValue(UserRoleEnums.User.Name);
    }
}
