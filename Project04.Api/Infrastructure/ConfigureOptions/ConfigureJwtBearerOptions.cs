namespace Project04.Api.Infrastructure.ConfigureOptions
{
    public class ConfigureJwtBearerOptions : IConfigureNamedOptions<JwtBearerOptions>
    {
        private readonly IAppSettingsProvider _appSettingsProvider;

        public ConfigureJwtBearerOptions(IAppSettingsProvider appSettingsProvider)
        {
            _appSettingsProvider = appSettingsProvider;
        }

        public void Configure(JwtBearerOptions options)
        {
            options.TokenValidationParameters = this._appSettingsProvider.GetTokenValidationParameters();
            options.RequireHttpsMetadata = false;
            options.SaveToken = false;
        }

        public void Configure(string? name, JwtBearerOptions options) => Configure(options);
    }
}
