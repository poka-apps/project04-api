using Project04.Application.Providers;

namespace Project04.Extensions
{
    public static class PhoneExtensions
    {
        public static int GetCallingCode(this Phone phone, ICountryProvider countryProvider)
        {
            countryProvider.ValidateNotNull();
            phone.ValidateNotNull();

            var result = countryProvider.GetCallingCode(phone.CountryCodeIso2);

            return result;
        }

        public static string ToString(this Phone phone, ICountryProvider phoneNumberUtil) =>
            $"+{phone.GetCallingCode(phoneNumberUtil)}{phone.Number}";
    }
}
