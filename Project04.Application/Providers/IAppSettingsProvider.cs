namespace Project04.Application.Providers
{
    public interface IAppSettingsProvider
    {
        EnvironmentEnums Environment { get; }
        string OriginWebApplication { get; }
        (
            int refreshTokenLifetime,
            int accessTokenLifetime,
            string audience,
            string secret,
            string issuer
        ) Jwt { get; }
        (
            string connectionString,
            long migrationVersion,
            bool migrationUp
        ) Database { get; }
    }
}
