namespace Project04.Infrastructure.Migrations
{
    public abstract class BaseMigration : Migration
    {
        protected IServiceProvider? ServiceProvider { get; }

        protected BaseMigration()
        {
            this.ServiceProvider = MigrationTools
                                        .ServiceProvider?
                                        .CreateScope()
                                        .ServiceProvider;
        }
    }
}