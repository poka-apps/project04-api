namespace Project04.Infrastructure.Migrations
{
    public static class MigrationTools
    {
        internal static IServiceProvider? ServiceProvider { get; private set; }

        public static void Migrate(IServiceProvider serviceProvider, ILogger logger)
        {
            using var serviceScope = serviceProvider.CreateScope();

            ServiceProvider = serviceScope.ServiceProvider;

            var appSettingsProvider = ServiceProvider.GetRequiredService<IAppSettingsProvider>();
            var migrationRunner = ServiceProvider.GetRequiredService<IMigrationRunner>();
            var hasMigrationsToApply = true;

            if (appSettingsProvider.Database.migrationUp)
            {
                try
                {
                    migrationRunner.HasMigrationsToApplyUp(appSettingsProvider.Database.migrationVersion);
                }
                catch
                {
                    logger.LogInformation("No migrations to apply.");
                    hasMigrationsToApply = false;
                }

                if (hasMigrationsToApply)
                {
                    migrationRunner.MigrateUp(appSettingsProvider.Database.migrationVersion);
                }
            }
            else
            {
                try
                {
                    migrationRunner.HasMigrationsToApplyDown(appSettingsProvider.Database.migrationVersion);
                }
                catch
                {
                    logger.LogInformation("No migrations to apply.");
                    hasMigrationsToApply = false;
                }

                if (hasMigrationsToApply)
                {
                    migrationRunner.MigrateDown(appSettingsProvider.Database.migrationVersion);
                }
            }

            ServiceProvider = null;
        }
    }
}
