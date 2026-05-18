using Project04.Api.Infrastructure.DocumentFilters;
using Project04.Api.Infrastructure.OperationFilters;

namespace Project04.Api.Infrastructure.ConfigureOptions
{
    public class ConfigureSwaggerOptions : IConfigureNamedOptions<SwaggerGenOptions>
    {
        public void Configure(SwaggerGenOptions swaggerGenOptions)
        {
            {
                swaggerGenOptions
                    .AddSecurityDefinition(
                        "Bearer",
                        new OpenApiSecurityScheme
                        {
                            Description = "JWT Authorization header using the Bearer scheme.",
                            Name = "Authorization",
                            In = ParameterLocation.Header,
                            Type = SecuritySchemeType.Http,
                            BearerFormat = "jwt",
                            Scheme = JwtBearerDefaults.AuthenticationScheme
                        }
                    );

                swaggerGenOptions
                    .AddSecurityRequirement(
                        l => {
                            var OpenApiSecurityRequirement = new OpenApiSecurityRequirement
                            {
                                { 
                                    new OpenApiSecuritySchemeReference(referenceId: JwtBearerDefaults.AuthenticationScheme), 
                                    [] 
                                }
                            };

                            return OpenApiSecurityRequirement;
                        }
                    );
            }

            swaggerGenOptions
                .SwaggerDoc(
                    "v1",
                    new OpenApiInfo
                    {
                        Title = GetType().Assembly.GetName().Name,
                        Version = "v1"
                    }
                );

            swaggerGenOptions
                .IncludeXmlComments(
                    Path.Combine(
                        AppContext.BaseDirectory,
                        $"{GetType().Assembly.GetName().Name}.xml"
                    )
                );

            swaggerGenOptions
                .DocInclusionPredicate((_, apiDescription) => !string.IsNullOrWhiteSpace(apiDescription.GroupName));

            swaggerGenOptions
                .TagActionsBy(apiDescription => [apiDescription.GroupName]);

            swaggerGenOptions
                .DocumentFilter<EnumDescriptionsDocumentFilter>();

            swaggerGenOptions
                .OperationFilter<CultureOperationFilter>();
        }

        public void Configure(string? name, SwaggerGenOptions options) => Configure(options);
    }
}
