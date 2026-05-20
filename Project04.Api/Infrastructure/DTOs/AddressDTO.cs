namespace Project04.Api.Infrastructure.DTOs
{
    public class AddressDTO
    {
        public string? Number { get; set; }
        public string? Street { get; set; }
        public string? Street2 { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public string CountryCodeISO2 { get; set; }

        public AddressDTO()
        {
        }

        public AddressDTO(Address address)
            : this()
        {
            address.ValidateNotNull();

            CountryCodeISO2 = address.CountryCodeISO2;
            PostalCode = address.PostalCode;
            Street2 = address.Street2;
            Street = address.Street;
            Number = address.Number;
            City = address.City;
        }

        public Address GetAddress() => new(
            countryCodeISO2: this.CountryCodeISO2,
            postalCode: this.PostalCode, 
            street2: this.Street2, 
            street: this.Street, 
            number: this.Number,
            city: this.City
        );
    }
}
