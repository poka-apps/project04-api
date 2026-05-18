namespace Project04.Api.Infrastructure.Providers
{
    internal class AppSettingsProvider : IAppSettingsProvider
    {
        private readonly IConfiguration _configuration;

        public AppSettingsProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public EnvironmentEnums Environment => EnvironmentEnums.FromValue(this._configuration.GetValue<string>("EnvironmentName")!);

        public (int accessTokenLifetime, string audience, string secret, string issuer) Jwt =>
            (
                //accessTokenLifetime
                this._configuration.GetValue<int>("Jwt:AccessTokenLifetime")!,
                //audience
                this._configuration.GetValue<string>("Jwt:Audience")!,
                //secret
                this._configuration.GetValue<string>("Jwt:Secret")!,
                //issuer
                this._configuration.GetValue<string>("Jwt:Issuer")!
            );

        public string OriginWebApplication => this._configuration.GetValue<string>("OriginWebApplication")!;

        public string ApplicationName => this._configuration.GetValue<string>("ApplicationName")!;

        public short AccessTokenLifetime => this._configuration.GetValue<short>("AccessTokenLifetime");

        public (string connectionString, string dataBaseName, bool allowUsingOfTransaction) Master => (
            this._configuration.GetValue<string>("DataBase:ConnectionString")!,
            this._configuration.GetValue<string>("DataBase:Name")!,
            this._configuration.GetValue<bool>("DataBase:AllowUsingOfTransaction")
        );

        public (
            string connectionString,
            long migrationVersion,
            bool migrationUp
        ) Database => (
            this._configuration.GetValue<string>("DataBase:ConnectionString")!,
            this._configuration.GetValue<long>("DataBase:Migration:Version")!,
            this._configuration.GetValue<string>("DataBase:Migration:Type")?.ToUpper() != "DOWN"
        );

        public TValue Get<TValue>(string key)
        {
            #region Validations

            key.ValidateHasValue();

            #endregion

            var result = this._configuration.GetValue<TValue>(key);

            return result!;
        }
    }
}
