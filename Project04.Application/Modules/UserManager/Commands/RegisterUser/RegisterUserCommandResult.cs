namespace Project04.Application.UserManager.Commands
{
    public record RegisterUserCommandResult
    {
        public UserId UserId { get; init; } = null!;
    }
}
