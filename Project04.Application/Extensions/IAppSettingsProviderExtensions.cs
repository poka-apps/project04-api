using Project04.Application.Providers;

namespace Project04.Extensions
{
    public static class IAppSettingsProviderExtensions
    {
        public static TokenValidationParameters GetTokenValidationParameters(this IAppSettingsProvider appSettingsProvider)
            => new TokenValidationParameters
            {
                IssuerSigningKey = new SymmetricSecurityKey(appSettingsProvider.Jwt.secret.ToUTF8Bytes()),
                ValidAudience = appSettingsProvider.Jwt.audience,
                ValidIssuer = appSettingsProvider.Jwt.issuer,
                ValidateIssuerSigningKey = true,
                ClockSkew = TimeSpan.Zero,
                ValidateLifetime = true,
                ValidateAudience = true,
                ValidateIssuer = true
            };
    }
}
