namespace Project04.Application.Commands
{
    public record GenerateUserAccessTokenCommandResult
    {
        public AccessToken AccessToken { get; init; } = null!;
    }
}
