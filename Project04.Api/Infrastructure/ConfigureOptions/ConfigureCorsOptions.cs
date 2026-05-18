using Microsoft.AspNetCore.Cors.Infrastructure;

namespace Project04.Api.Infrastructure.ConfigureOptions
{
    public class ConfigureCorsOptions : IConfigureNamedOptions<CorsOptions>
    {
        private readonly IAppSettingsProvider _appSettingsProvider;

        public ConfigureCorsOptions(IAppSettingsProvider appSettingsProvider)
        {
            _appSettingsProvider = appSettingsProvider;
        }

        public void Configure(CorsOptions corsOptions)
        {
            corsOptions
                .AddPolicy(
                    "default-cors",
                    configurePolicy =>
                    {
                        configurePolicy
                            .WithOrigins(this._appSettingsProvider.OriginWebApplication.Split(";"))
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    }
                );
        }

        public void Configure(string? name, CorsOptions corsOptions) => Configure(corsOptions);
    }
}
