using Microsoft.AspNetCore.Localization;

namespace Project04.Api.Infrastructure.ConfigureOptions
{
    /// <summary>
    /// 
    /// </summary>
    public class ConfigureRequestLocalizationOptions : IConfigureNamedOptions<RequestLocalizationOptions>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public void Configure(RequestLocalizationOptions options)
        {
            while (options.RequestCultureProviders.Any())
            {
                options.RequestCultureProviders.RemoveAt(0);
            }

            options.RequestCultureProviders.Insert(0, new QueryStringRequestCultureProvider());
            options.RequestCultureProviders.Insert(1, new AcceptLanguageHeaderRequestCultureProvider());
            options.RequestCultureProviders.Insert(2, new CookieRequestCultureProvider());

            options.DefaultRequestCulture = new RequestCulture(Constants.Language.English);
            options.SupportedUICultures = Constants.Language.SupportedCultures;
            options.SupportedCultures = Constants.Language.SupportedCultures;
        }

        /// <summary>
        /// Configures the specified localization options for the given named instance.
        /// </summary>
        /// <param name="name">The name of the options instance to configure. This value can be null to configure the default instance.</param>
        /// <param name="options">The localization options to be configured. Cannot be null.</param>
        public void Configure(string? name, RequestLocalizationOptions options) => Configure(options);
    }
}
