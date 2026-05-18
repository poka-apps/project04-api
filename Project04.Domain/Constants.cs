using Project04.Domain.ContractResolvers;

namespace Project04.Domain
{
    public static class Constants
    {
        public static class Language
        {
            public const string French = "fr";
            public const string English = "en";

            public static CultureInfo[] SupportedCultures = [
                new(English),
                new(French)
            ];
        }

        public static readonly JsonSerializerSettings DefaultJsonSerializerSettings = new()
        {
            ContractResolver = new CamelCasePropertyNames_PrivatePropertyContractResolver(),
            Formatting = Formatting.None,
            MaxDepth = 3
        };
    }
}
