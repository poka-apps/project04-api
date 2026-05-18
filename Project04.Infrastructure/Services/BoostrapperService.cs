using Project04.Infrastructure.Migrations;

namespace Project04.Infrastructure.Services
{
    public class BoostrapperService : IBoostrapperService
    {
        private readonly ILogger<BoostrapperService> _logger;
        private readonly IServiceProvider _serviceProvider;

        public BoostrapperService(IServiceProvider serviceProvider, ILogger<BoostrapperService> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken = default)
        {
            MigrationTools
                .Migrate(
                    serviceProvider: this._serviceProvider,
                    logger: this._logger
                );

            return Task.CompletedTask;
        }
    }
}