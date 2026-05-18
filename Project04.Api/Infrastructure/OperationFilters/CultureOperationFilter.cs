namespace Project04.Api.Infrastructure.OperationFilters
{
    public class CultureOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters is null)
            {
                operation.Parameters = [];
            }

            if (!operation.Parameters.Any(l => l.Name!.Equals("culture", StringComparison.OrdinalIgnoreCase)))
            {
                operation.Parameters.Add(
                    new OpenApiParameter()
                    {
                        Description = "Culture parameter (en, fr)",
                        In = ParameterLocation.Query,
                        Name = "culture",
                        Required = false
                    }
                );
            }
        }
    }
}
