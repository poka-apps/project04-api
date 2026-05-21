namespace Project04.Domain.ValueObjects
{
    public sealed record Address
    {
        public string? Number { get; private set; }
        public string? Street { get; private set; }
        public string? Street2 { get; private set; }
        public string? City { get; private set; }
        public string? PostalCode { get; private set; }
        public string CountryCodeISO2 { get; private set; }

        public Address()
        {
        }

        public Address(
            string countryCodeISO2,
            string? number = null,
            string? street = null,
            string? street2 = null,
            string? city = null,
            string? postalCode = null
        )
            : this()
        {
            countryCodeISO2.ValidateNotEmpty();

            this.CountryCodeISO2 = countryCodeISO2.Humanize(LetterCasing.AllCaps);
            this.PostalCode = postalCode;
            this.Street2 = street2;
            this.Number = number;
            this.Street = street;
            this.City = city;
        }

        public override string ToString() =>
            string.Join(
                separator: ", ",
                values: new[] {
                    string.Join(
                        separator: " ", 
                        values: new[] { 
                            this.Number, 
                            this.Street
                        }
                        .Where(l => !string.IsNullOrWhiteSpace(l))
                    ),
                    this.Street2,
                    this.PostalCode,
                    this.City,
                    this.CountryCodeISO2?.Humanize(LetterCasing.AllCaps)
                }
                .Where(l => !string.IsNullOrWhiteSpace(l))
            );
    }
}
