namespace Project04.Application.Providers
{
    public interface ICountryProvider
    {
        IEnumerable<short> GetCallingCodes(string countryCodeIso2);
        IEnumerable<(string codeIso2, string name)> GetCountries();
        short GetCallingCode(string countryCodeIso2);
    }
}
