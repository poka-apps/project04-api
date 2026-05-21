namespace Project04.Application.Queries
{
    public record GetVersionQueryResult
    {
        public Version Version { get; init; } = null!;
        public EnvironmentEnums Environment { get; init; } = null!;
    }
}
