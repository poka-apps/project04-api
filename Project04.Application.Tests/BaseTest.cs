using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using Project04.Application.Repositories;
using Project04.Application.Tests.Providers;
using Project04.Domain.ValueObjects;
using Project04.Infrastructure.Migrations;
using System.Globalization;

namespace Project04.Application.Tests
{
    public class BaseTest : BaseCommonTest
    {
        protected IDbRepository DbRepository => ServiceProvider!.GetRequiredService<IDbRepository>();
        protected IMediator Mediator => ServiceProvider!.GetRequiredService<IMediator>();

        public BaseTest()
        {
            ServiceProvider = new ServiceCollection()
                                    .AddSingleton(this.Configuration)
                                    .AddInfrastructure()
                                    .AddScoped(GetMockedICurrentCultureProvider)
                                    .AddScoped(GetMockedICurrentUserProvider)
                                    .AddSingleton<IAppSettingsProvider, AppSettingsProvider>()
                                    .BuildServiceProvider();

            var logger = this.ServiceProvider.GetRequiredService<ILogger<BaseTest>>();

            MigrationTools.Migrate(serviceProvider: ServiceProvider, logger: logger);
        }

        private static ICurrentCultureProvider GetMockedICurrentCultureProvider(IServiceProvider serviceProvider)
        {
            var mockICurrentCultureProvider = new Mock<ICurrentCultureProvider>();

            mockICurrentCultureProvider
                .Setup(l => l.Language)
                .Returns(LanguageEnums.French);

            mockICurrentCultureProvider
                .Setup(l => l.CurrentCulture)
                .Returns(new CultureInfo("fr"));

            return mockICurrentCultureProvider.Object;
        }

        private static ICurrentUserProvider GetMockedICurrentUserProvider(IServiceProvider serviceProvider)
        {
            var mockICurrentUserProvider = new Mock<ICurrentUserProvider>();

            mockICurrentUserProvider
                .Setup(l => l.UserId)
                .Returns(UserId.GenerateGuid<UserId>);

            mockICurrentUserProvider
                .Setup(l => l.IsAuthenticated)
                .Returns(true);

            return mockICurrentUserProvider.Object;
        }
    }
}
