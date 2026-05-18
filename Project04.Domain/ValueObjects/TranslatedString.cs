using Project04.Domain.Enums;

namespace Project04.Domain.ValueObjects
{
    public record TranslatedString
    {
        public string? English { get; private set; }
        public string? French { get; private set; }

        public TranslatedString()
        { }

        public TranslatedString(string valueEN, string valueFR)
        {
            this.English = valueEN;
            this.French = valueFR;
        }

        public string GetValue(CultureInfo culture)
        {
            var result = this.English;

            if (culture.TwoLetterISOLanguageName.ToUpper() == LanguageEnums.French.GetCodeISO2().ToUpper())
            {
                result = this.French;
            }

            return result!;
        }

        public string GetValue(LanguageEnums language)
        {
            var result = this.English;

            if (language == LanguageEnums.French)
            {
                result = this.French;
            }

            return result!;
        }

        public override string ToString() => $"English={this.English}, French={this.French}";
    }
}
