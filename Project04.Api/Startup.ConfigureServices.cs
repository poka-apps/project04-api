using Project04.Api.Infrastructure.ConfigureOptions;
using Project04.Api.Infrastructure.Providers;

namespace Project04.Api
{
    public partial class Startup
    {
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddHttpContextAccessor();

            serviceCollection
                .AddInfrastructure();

            serviceCollection
                .AddHealthChecks();

            serviceCollection
                .AddControllers();

            serviceCollection
                .AddMemoryCache();

            serviceCollection
                .ConfigureOptions<ConfigureJwtBearerOptions>()
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer();

            serviceCollection
                .ConfigureOptions<ConfigureRequestLocalizationOptions>();

            serviceCollection
                .AddSwaggerGen()
                .ConfigureOptions<ConfigureSwaggerOptions>();

            serviceCollection
                .AddCors()
                .ConfigureOptions<ConfigureCorsOptions>();

            // Providers
            {
                serviceCollection
                    .AddScoped<ICurrentUserProvider, CurrentUserProvider>()
                    .AddSingleton<IAppSettingsProvider, AppSettingsProvider>();
            }

            // HealthCheck
            {
                serviceCollection
                    .AddHealthChecks();
            }
        }
    }
}
