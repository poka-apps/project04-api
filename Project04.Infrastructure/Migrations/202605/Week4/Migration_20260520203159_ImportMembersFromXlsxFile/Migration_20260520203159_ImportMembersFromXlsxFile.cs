using Humanizer;

namespace Project04.Infrastructure.Migrations
{
    [Migration(20260520203159, description: nameof(Migration_20260520203159_ImportMembersFromXlsxFile))]
    public class Migration_20260520203159_ImportMembersFromXlsxFile : BaseMigration
    {
        public override void Up()
        {
            var commands = new List<CreateMemberCommand>();
            var filePath =  Path.Combine(
                                AppDomain.CurrentDomain.BaseDirectory, 
                                "Migrations", 
                                "202605", 
                                "Week4", 
                                "Migration_20260520203159_ImportMembersFromXlsxFile", 
                                "Data.xlsx"
                            );

            using var workbook = new XLWorkbook(filePath);
            var worksheet = workbook.Worksheet("Identité membres");

            foreach (var row in worksheet.RowsUsed())
            {
                var firstname = row.Cell(1).GetValue<string>();
                var lastname = row.Cell(2).GetValue<string>();
                var nickname = row.Cell(3).GetValue<string>();
                var city = row.Cell(4).GetValue<string>();
                var telephone = row.Cell(5).GetValue<string>();

                var address = default(Address);
                {
                    if (city?.Trim().ToLower().Contains("luxembourg") == true)
                    {
                        address = new Address(
                            city: city.Humanize(LetterCasing.AllCaps),
                            countryCodeISO2: "LU"
                        );
                    }
                    else if (city!.HasValue())
                    {
                        address = new Address(
                            city: city!.Humanize(LetterCasing.AllCaps),
                            countryCodeISO2: "FR"
                        );
                    }
                }

                var phone = default(Phone);
                {
                    if (telephone?.Trim().Contains("+352") == true)
                    {
                        phone = new Phone(
                            countryCodeIso2: "LU",
                            number: int.Parse(telephone.Trim().Replace("+352", string.Empty))
                        );
                    }
                    else if (telephone?.Trim().Contains("+33") == true)
                    {
                        phone = new Phone(
                            countryCodeIso2: "FR",
                            number: int.Parse(telephone.Trim().Replace("+33", string.Empty))
                        );
                    }
                }                

                var command =   new CreateMemberCommand(
                                    firstname: firstname?.ToName(),
                                    lastname: lastname?.ToName(),
                                    nickname: nickname?.ToName(),
                                    address: address,
                                    phone: phone
                                );
                commands.Add(command);
            }
        }

        public override void Down()
        {
        }
    }
}
