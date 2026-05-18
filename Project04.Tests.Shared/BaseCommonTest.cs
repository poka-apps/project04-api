using Microsoft.Extensions.Configuration;

[assembly: TestCollectionOrderer(
    "Project03.Tests.Shared.TestCaseOrdererImplementation",
    "Project03.Tests.Shared"
)]
[assembly: CollectionBehavior(DisableTestParallelization = true)]

namespace Project04.Tests.Shared
{
    public abstract class BaseCommonTest
    {
        protected IServiceProvider? ServiceProvider { get; set; }
        protected IConfiguration Configuration { get; set; }

        protected BaseCommonTest()
        {
            AppDomain
                .CurrentDomain
                .SetData(
                    name: "DataDirectory",
                    data: Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources")
                );

            Configuration = new ConfigurationBuilder()
                                .AddJsonFile("appsettings.json", optional: false)
                                .Build();
        }
    }
}
