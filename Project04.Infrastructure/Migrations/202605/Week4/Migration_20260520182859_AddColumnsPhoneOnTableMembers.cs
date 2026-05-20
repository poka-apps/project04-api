namespace Project04.Infrastructure.Migrations
{
    [Migration(20260520182859, description: nameof(Migration_20260520182859_AddColumnsPhoneOnTableMembers))]
    public class Migration_20260520182859_AddColumnsPhoneOnTableMembers : AutoReversingMigration
    {
        public override void Up()
        {
            Create
                .Column("Phone.CountryCodeIso2")
                    .OnTable("MEMBERS")
                        .AsString(2)
                        .Nullable();

            Create
                .Column("Phone.Number")
                    .OnTable("MEMBERS")
                        .AsInt32()
                        .Nullable();
        }
    }
}
