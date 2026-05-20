namespace Project04.Application.Tests.Providers
{
    public class AppSettingsProvider : IAppSettingsProvider
    {
        private readonly IConfiguration _configuration;

        public AppSettingsProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public EnvironmentEnums Environment => EnvironmentEnums.FromValue(this._configuration.GetValue<string>("EnvironmentName")!);

        public (
            string connectionString,
            long migrationVersion,
            bool migrationUp
        ) Database => (
            this._configuration.GetValue<string>("DataBase:ConnectionString")!,
            this._configuration.GetValue<long>("DataBase:Migration:Version")!,
            this._configuration.GetValue<string>("DataBase:Migration:Type")?.ToUpper() != "DOWN"
        );

        public (int refreshTokenLifetime, int accessTokenLifetime, string audience, string secret, string issuer) Jwt =>
            (
                //refreshTokenLifetime
                this._configuration.GetValue<int>("Jwt:RefreshTokenLifetime")!,
                //accessTokenLifetime
                this._configuration.GetValue<int>("Jwt:AccessTokenLifetime")!,
                //audience
                this._configuration.GetValue<string>("Jwt:Audience")!,
                //secret
                this._configuration.GetValue<string>("Jwt:Secret")!,
                //issuer
                this._configuration.GetValue<string>("Jwt:Issuer")!
            );

        public (string clientId, string clientSecret, string graphUrl) Facebook =>
            (
                //clientId
                this._configuration.GetValue<string>("Facebook:ClientId")!,
                //clientSecret
                this._configuration.GetValue<string>("Facebook:ClientSecret")!,
                //graphUrl
                this._configuration.GetValue<string>("Facebook:GraphUrl")!
            );

        public (string clientId, string clientSecret) Google =>
            (
                //clientId
                this._configuration.GetValue<string>("Google:ClientId")!,
                //clientSecret
                this._configuration.GetValue<string>("Google:ClientSecret")!
            );

        public string OriginWebApplication => this._configuration.GetValue<string>("OriginWebApplication")!;

        public string ApplicationName => this._configuration.GetValue<string>("ApplicationName")!;

        public short AccessTokenLifetime => this._configuration.GetValue<short>("AccessTokenLifetime");

        public (string connectionString, string dataBaseName, bool allowUsingOfTransaction) Master => (
            this._configuration.GetValue<string>("DataBase:ConnectionString")!,
            this._configuration.GetValue<string>("DataBase:Name")!,
            this._configuration.GetValue<bool>("DataBase:AllowUsingOfTransaction")
        );

        public (string connectionString, string dataBaseName, bool allowUsingOfTransaction) EventStore => (
            this._configuration.GetValue<string>("DataBase:ConnectionString")!,
            this._configuration.GetValue<string>("DataBase:Name")!,
            this._configuration.GetValue<bool>("DataBase:AllowUsingOfTransaction")
        );

        public (string connectionString, string dataBaseName, bool allowUsingOfTransaction) RequestStore => (
            this._configuration.GetValue<string>("DataBase:ConnectionString")!,
            this._configuration.GetValue<string>("DataBase:Name")!,
            this._configuration.GetValue<bool>("DataBase:AllowUsingOfTransaction")
        );

        public (string apiSecret, string cloudName, string apiKey) Cloudinary => (
            this._configuration.GetValue<string>("Cloudinary:ApiSecret")!,
            this._configuration.GetValue<string>("Cloudinary:CloudName")!,
            this._configuration.GetValue<string>("Cloudinary:ApiKey")!
        );

        public TValue? Get<TValue>(string key)
        {
            #region Validations

            key.ValidateHasValue();

            #endregion

            var result = this._configuration.GetValue<TValue>(key);

            return result;
        }
    }
}
