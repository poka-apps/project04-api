namespace Project04.Api.Infrastructure.DTOs
{
    public class PhoneDTO
    {
        public string CountryCodeIso2 { get; set; }
        public int Number { get; set; }

        public PhoneDTO()
        {
        }

        public PhoneDTO(Phone phone)
            : this()
        {
            phone.ValidateNotNull();

            CountryCodeIso2 = phone.CountryCodeIso2;
            Number = phone.Number;
        }

        public Phone GetPhone() => new(
            countryCodeIso2: this.CountryCodeIso2,
            number: this.Number
        );
    }
}
