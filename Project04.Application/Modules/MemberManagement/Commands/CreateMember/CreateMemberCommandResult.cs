namespace Project04.Application.MemberManagement.Commands
{
    public record CreateMemberCommandResult
    {
        public MemberId MemberId { get; init; } = null!;
        public UserId UserId { get; init; } = null!;
    }
}
