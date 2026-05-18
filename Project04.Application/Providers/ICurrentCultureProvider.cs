namespace Project04.Application.Providers
{
    public interface ICurrentCultureProvider
    {
        CultureInfo CurrentCulture { get; }
        LanguageEnums Language { get; }
    }
}
