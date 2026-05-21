using Humanizer;

namespace Project04.Infrastructure.Migrations
{
    [Migration(20260520203159, description: nameof(Migration_20260520203159_ImportMembersFromXlsxFile))]
    public class Migration_20260520203159_ImportMembersFromXlsxFile : BaseMigration
    {
        public override void Up()
        {
            var dbRepository = this.ServiceProvider.GetRequiredService<IDbRepository>();
            var mediator = this.ServiceProvider.GetRequiredService<IMediator>();
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
            var rows = worksheet.RowsUsed().Skip(1);

            foreach (var row in rows)
            {
                var firstnameValue = row.Cell(1).GetValue<string>();
                var lastnameValue = row.Cell(2).GetValue<string>();
                var nicknameValue = row.Cell(3).GetValue<string>();
                var city = row.Cell(4).GetValue<string>();
                var telephone = row.Cell(5).GetValue<string>();

                if (lastnameValue?.Trim().ToLower() == "total")
                {
                    continue;
                }

                var firstname = default(Name);
                {
                    if (firstnameValue.HasValue())
                    {
                        firstname = new Name(firstnameValue);
                    }
                }

                var lastname = default(Name);
                {
                    if (lastnameValue.HasValue())
                    {
                        lastname = new Name(lastnameValue);
                    }
                }

                var nickname = default(Name);
                {
                    if (nicknameValue.HasValue())
                    {
                        nickname = new Name(nicknameValue);
                    }
                }

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
                                    firstname: firstname,
                                    lastname: lastname!,
                                    nickname: nickname,
                                    address: address,
                                    phone: phone
                                );
                commands.Add(command);
            }

            dbRepository.BeginTransaction();

            foreach (var command in commands)
            {
                mediator
                    .Send(command)
                    .Wait();
            }

            dbRepository.CommitTransaction();
        }

        public override void Down()
        {
            var dbRepository = this.ServiceProvider.GetRequiredService<IDbRepository>();

            dbRepository.Members.ExecuteDelete();
            dbRepository.Users.ExecuteDelete();
        }
    }
}
