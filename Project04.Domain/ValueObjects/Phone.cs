namespace Project04.Domain.ValueObjects
{
    public record Phone
    {
        public string CountryCodeIso2 { get; private set; }
        public int Number { get; private set; }

        public Phone()
        {
        }

        public Phone(string countryCodeIso2, int number)
            : this()
        {
            countryCodeIso2.ValidateNotEmpty();

            CountryCodeIso2 = countryCodeIso2;
            Number = number;
        }

        public int GetCallingCode(PhoneNumberUtil phoneNumberUtil)
        {
            phoneNumberUtil.ValidateNotNull();

            var result = phoneNumberUtil.GetCountryCodeForRegion(this.CountryCodeIso2);

            return result;
        }

        public string ToString(PhoneNumberUtil phoneNumberUtil) =>
            $"+{this.GetCallingCode(phoneNumberUtil)}{Number}";
    }
}
