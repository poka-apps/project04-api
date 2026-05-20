namespace Project04.Domain.ValueObjects
{
    public sealed record Address
    {
        public string Street { get; private set; }
        public string? Street2 { get; private set; }
        public string City { get; private set; }
        public string PostalCode { get; private set; }
        public string CountryCodeISO2 { get; private set; }

        public Address(
            string street,
            string? street2,
            string city,
            string postalCode,
            string countryCodeISO2
        )
        {
            this.Street = street;
            this.Street2 = street2;
            this.City = city;
            this.PostalCode = postalCode;
            this.CountryCodeISO2 = countryCodeISO2;
        }

        public override string ToString() =>
            string.Join(
                separator: ", ",
                values: new[] {
                    this.Street,
                    this.Street2,
                    this.PostalCode,
                    this.City,
                    this.CountryCodeISO2
                }
                .Where(l => !string.IsNullOrWhiteSpace(l))
            );
    }
}
