namespace Project04.Infrastructure.Providers
{
    internal class CurrentCultureProvider : ICurrentCultureProvider
    {
        private readonly CultureInfo _currentCulture;

        public CurrentCultureProvider()
        {
            _currentCulture = Thread.CurrentThread.CurrentCulture;
        }

        public CultureInfo CurrentCulture => this._currentCulture;

        public LanguageEnums Language =>
            this._currentCulture.TwoLetterISOLanguageName.ToLower() == Constants.Language.French.ToLower()
                ? LanguageEnums.French
                : LanguageEnums.English;
    }
}
