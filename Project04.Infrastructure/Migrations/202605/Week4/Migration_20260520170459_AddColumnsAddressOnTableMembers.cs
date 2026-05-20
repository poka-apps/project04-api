namespace Project04.Infrastructure.Migrations
{
    [Migration(20260520170459, description: nameof(Migration_20260520170459_AddColumnsAddressOnTableMembers))]
    public class Migration_20260520170459_AddColumnsAddressOnTableMembers : AutoReversingMigration
    {
        public override void Up()
        {
            Create
                .Column("Address.Street")
                    .OnTable("MEMBERS")
                        .AsString(100)
                        .Nullable()
                        .WithColumnDescription("Part of address");

            Create
                .Column("Address.Street2")
                    .OnTable("MEMBERS")
                        .AsString(100)
                        .Nullable()
                        .WithColumnDescription("Part of address");

            Create
                .Column("Address.City")
                    .OnTable("MEMBERS")
                        .AsString(100)
                        .Nullable()
                        .WithColumnDescription("Part of address");

            Create
                .Column("Address.PostalCode")
                    .OnTable("MEMBERS")
                        .AsString(20)
                        .Nullable()
                        .WithColumnDescription("Part of address");

            Create
                .Column("Address.CountryCodeISO2")
                    .OnTable("MEMBERS")
                        .AsString(2)
                        .Nullable()
                        .WithColumnDescription("Part of address");
        }
    }
}
