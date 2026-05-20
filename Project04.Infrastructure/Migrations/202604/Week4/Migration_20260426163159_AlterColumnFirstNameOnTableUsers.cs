namespace Project04.Infrastructure.Migrations
{
    [Migration(20260426163159, description: nameof(Migration_20260426163159_AlterColumnFirstNameOnTableUsers))]
    public class Migration_20260426163159_AlterColumnFirstNameOnTableUsers : Migration
    {
        public override void Up() =>
            Alter
                .Column("Firstname")
                    .OnTable("USERS")
                        .AsString(100)
                        .NotNullable();

        public override void Down() =>
            Alter
                .Column("Firstname")
                    .OnTable("USERS")
                        .AsString(100)
                        .Nullable();
    }
}
