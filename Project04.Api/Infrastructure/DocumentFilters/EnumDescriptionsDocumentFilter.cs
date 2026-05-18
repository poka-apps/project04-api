namespace Project04.Api.Infrastructure.DocumentFilters
{
    public class EnumDescriptionsDocumentFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            if (swaggerDoc.Paths.Any())
            {
                foreach (var pathItem in swaggerDoc.Paths.Values)
                {
                    foreach (var operation in pathItem.Operations!)
                    {
                        foreach (var operationParameter in operation.Value.Parameters!.Where(l => l.Schema?.Id is not null))
                        {
                            var reference = operationParameter.Schema!.Id!;
                            var descriptions = new List<string>();
                            var typeEnums = GetEnumType(reference);

                            foreach (var enumValue in Enum.GetValues(typeEnums))
                            {
                                var fieldInfo = typeEnums.GetField(Enum.GetName(typeEnums, enumValue)!);
                                var description = (Enum.Parse(typeEnums, $"{enumValue}") as Enum)!.GetDescription()!;
                                descriptions.Add($"{description} = {(int)enumValue}");
                            }

                            operationParameter.Description += $" ({string.Join(", ", descriptions)}).";
                            operationParameter.Description = operationParameter.Description.Trim();
                        }
                    }
                }
            }
        }

        private Type GetEnumType(string enumTypeName) =>
            AppDomain
                .CurrentDomain
                .GetAssemblies()
                .SelectMany(l => l.GetTypes())
                .First(l => l.FullName == enumTypeName);
    }
}
