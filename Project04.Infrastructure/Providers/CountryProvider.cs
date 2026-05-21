namespace Project04.Infrastructure.Providers
{
    internal class CountryProvider : ICountryProvider
    {
        private Nager.Country.CountryProvider _countryProvider;

        public CountryProvider()
        {
            _countryProvider = new();
        }

        public IEnumerable<short> GetCallingCodes(string countryCodeIso2)
        {
            countryCodeIso2.ValidateNotEmpty();

            countryCodeIso2 = countryCodeIso2.Humanize(LetterCasing.AllCaps);

            var result =    this._countryProvider
                                .GetCountry(countryCodeIso2)
                                .CallingCodes
                                .Select(l => short.Parse(l))
                                .ToArray();

            return result;
        }

        public IEnumerable<(string codeIso2, string name)> GetCountries()
        {
            var result = this._countryProvider
                                .GetCountries()
                                .Select(
                                    l => (
                                        l.Alpha2Code.ToString(), 
                                        l.CommonName
                                    )
                                )
                                .ToArray();

            return result;
        }

        public short GetCallingCode(string countryCodeIso2) =>
            this.GetCallingCodes(countryCodeIso2)
                .First();
    }
}
