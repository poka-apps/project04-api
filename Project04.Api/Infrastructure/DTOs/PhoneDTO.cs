namespace Project04.Api.Infrastructure.DTOs
{
    public class PhoneDTO
    {
        public string CountryCodeIso2 { get; set; }
        public string? FullNumber { get; set; }
        public int Number { get; set; }

        public PhoneDTO()
        {
        }

        public PhoneDTO(Phone phone, PhoneNumberUtil? phoneNumberUtil = null)
            : this()
        {
            phone.ValidateNotNull();

            CountryCodeIso2 = phone.CountryCodeIso2;
            Number = phone.Number;

            if (phoneNumberUtil != null)
            {
                FullNumber = phone.ToString(phoneNumberUtil);
            }
        }

        public Phone GetPhone() => new(
            countryCodeIso2: this.CountryCodeIso2,
            number: this.Number
        );
    }
}
