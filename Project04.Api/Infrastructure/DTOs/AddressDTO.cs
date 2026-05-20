namespace Project04.Api.Infrastructure.DTOs
{
    public class AddressDTO
    {
        public string Street { get; set; }
        public string? Street2 { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string CountryCodeISO2 { get; set; }
        public string CountryName { get; set; }

        public AddressDTO()
        {
        }

        public AddressDTO(Address address, ICountryProvider countryProvider)
            : this()
        {
            countryProvider.ValidateNotNull();
            address.ValidateNotNull();

            var countryInfo = countryProvider.GetCountry(address.CountryCodeISO2);

            countryInfo.ValidateNotNull();

            CountryCodeISO2 = address.CountryCodeISO2;
            CountryName = countryInfo.CommonName;
            PostalCode = address.PostalCode;
            Street2 = address.Street2;
            Street = address.Street;
            City = address.City;
        }

        public Address GetAddress() => new(
            countryCodeISO2: this.CountryCodeISO2,
            postalCode: this.PostalCode, 
            street2: this.Street2, 
            street: this.Street, 
            city: this.City
        );
    }
}
