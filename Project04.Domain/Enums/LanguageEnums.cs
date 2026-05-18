using Project04.Domain.ValueObjects;

namespace Project04.Domain.Enums
{
    public sealed class LanguageEnums : BaseEnums<LanguageEnums>
    {
        public static readonly LanguageEnums English = new(0, "en", "eng", "English", new TranslatedString("English", "Anglais"));
        public static readonly LanguageEnums French = new(1, "fr", "fra", "Français", new TranslatedString("French", "Français"));

        public LanguageEnums(int value, string name)
            : base(value, name)
        {
            var @enum = FromValue(value);

            _translatedName = @enum._translatedName;
            _officialName = @enum._officialName;
            _codeISO2 = @enum._codeISO2;
            _codeISO3 = @enum._codeISO3;
        }

        private LanguageEnums(int index, string codeISO2, string codeISO3, string officialName, TranslatedString translatedName)
            : base(index, officialName)
        {
            _translatedName = translatedName;
            _officialName = officialName;
            _codeISO2 = codeISO2;
            _codeISO3 = codeISO3;
        }

        private readonly TranslatedString _translatedName;

        private readonly string _officialName;
        private readonly string _codeISO2;
        private readonly string _codeISO3;

        public TranslatedString GetTranslatedName() => this._translatedName;

        public string GetOfficialName() => this._officialName;

        public string GetCodeISO2() => this._codeISO2;

        public string GetCodeISO3() => this._codeISO3;

        public static LanguageEnums FromValueCodeISO2(string codeISO2)
        {
            var result = CreateEnumerations()
                            .Select(l => l.Value)
                            .FirstOrDefault(l => l.GetCodeISO2().ToLower() == codeISO2.ToLower().Trim());

            if (result == default)
            {
                throw new AppException(AppErrorEnums.EnumValueNotFound);
            }

            return result;
        }
    }
}

