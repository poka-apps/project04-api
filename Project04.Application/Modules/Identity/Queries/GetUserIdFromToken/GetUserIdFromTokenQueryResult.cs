namespace Project04.Application.Queries
{
    public record GetUserIdFromTokenQueryResult
    {
        public UserId UserId { get; init; } = null!;
    }
}
