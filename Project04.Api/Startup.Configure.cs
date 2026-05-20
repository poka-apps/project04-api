using Project04.Api.Infrastructure.Middlewares;

namespace Project04.Api
{
    public partial class Startup
    {
        public void Configure(
            IOptions<RequestLocalizationOptions> requestLocalizationOptions,
            IAppSettingsProvider appSettingsProvider,
            IBoostrapperService boostrapperService,
            IServiceProvider serviceProvider,
            ILogger<Startup> logger,
            IApplicationBuilder app
        )
        {
            // 1. Log and and enrich response with exception triggered.
            app.UseExceptionHandler(
                appBuilder =>
                {
                    appBuilder.UseRequestLocalization(requestLocalizationOptions.Value);
                    appBuilder.UseMiddleware<ExceptionMiddleware>();
                }
            );

            if (
                appSettingsProvider.Environment == EnvironmentEnums.Development ||
                appSettingsProvider.Environment == EnvironmentEnums.Test
            )
            {
                // 2. Build swagger
                app.UseSwagger();

                // 3. Configure UI of swagger in request
                app.UseSwaggerUI(
                    options =>
                    {
                        options.DocumentTitle = this.GetType().Assembly.GetName().Name;
                        options.SwaggerEndpoint(
                            $"/swagger/v1/swagger.json",
                            "v1"
                        );
                        options.DefaultModelsExpandDepth(-1);
                        options.EnablePersistAuthorization();
                    }
                );
            }

            // 4. Redirect request to protocole 'https'
            app.UseHttpsRedirection();

            // 5. Apply routing in request
            app.UseRouting();

            // 6. Add default cors policy
            app.UseCors("default-cors");

            // 7. Apply culture information for requests based on information provided by the client
            app.UseRequestLocalization(requestLocalizationOptions.Value);

            // 8. 
            app.UseAuthentication();

            // 9. Check authorization in request
            app.UseAuthorization();

            // 10. Map route to controllers
            app.UseEndpoints(
                endpoints => {
                    endpoints
                        .MapControllers()
                        .RequireAuthorization()
                        // TODO: Remove when security implemented.
                        .AllowAnonymous();
                }
            );

            // 11. HealthChecks
            app.UseHealthChecks("/health");

            boostrapperService
                .StartAsync()
                .Wait();
        }
    }
}
