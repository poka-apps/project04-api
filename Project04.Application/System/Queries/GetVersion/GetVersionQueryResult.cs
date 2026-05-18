namespace Project04.Application.Queries
{
    public record GetVersionQueryResult
    {
        public int Major { get; init; }
        public int Minor { get; init; }
        public int Build { get; init; }
        public int Revision { get; init; }
        public EnvironmentEnums Environment { get; init; }
    }
}
