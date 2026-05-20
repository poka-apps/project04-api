using Project04.Infrastructure.DbContexts;
using Project04.Infrastructure.Migrations;
using Project04.Infrastructure.PipelineBehaviors;
using Project04.Infrastructure.Providers;
using Project04.Infrastructure.Repositories;
using Project04.Infrastructure.Services;

namespace Project04.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            // FluentValidation 
            {
                serviceCollection
                    .AddValidatorsFromAssemblies(assemblies);
            }

            // FluentMigrator
            {
                serviceCollection
                    .AddFluentMigratorCore()
                    .ConfigureRunner(
                        runner =>
                        {
                            runner
                                .AddPostgres()
                                .WithGlobalConnectionString(
                                    serviceProvider =>
                                    {
                                        var appSettingsProvider = serviceProvider.GetRequiredService<IAppSettingsProvider>();

                                        return appSettingsProvider.Database.connectionString;
                                    }
                                )
                                .ScanIn(typeof(BaseMigration).Assembly)
                                    .For
                                    .Migrations();
                        }
                    )
                    .AddLogging(l => l.AddFluentMigratorConsole());
            }

            // Repositories
            {
                serviceCollection
                    .AddDbContext<AppDbContext>(
                        (serviceProvider, options) =>
                        {
                            var appSettingsProvider = serviceProvider.GetRequiredService<IAppSettingsProvider>();

                            options.UseNpgsql(appSettingsProvider.Database.connectionString);
                        }
                    )
                    .AddScoped<IDbRepository, DbRepository>();
            }

            // Services
            {
                serviceCollection
                    .AddSingleton<IBoostrapperService, BoostrapperService>();
            }

            // Providers
            {
                serviceCollection
                    .AddSingleton<ICountryProvider>(new CountryProvider());
            }

            // MediatR
            {
                serviceCollection
                    .AddMediatR(
                        config =>
                        {
                            // 1.
                            config.AddBehavior(typeof(IPipelineBehavior<,>), typeof(LoggingPipelineBehavior<,>));
                            // 2.
                            config.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));
                            // Register all handlers
                            config.RegisterServicesFromAssemblies(assemblies);
                        }
                    );
            }

            serviceCollection
                .AddLogging();

            serviceCollection
                .AddLocalization();

            serviceCollection
                .AddScoped<ICurrentCultureProvider, CurrentCultureProvider>();

            return serviceCollection;
        }
    }
}
