namespace Project04.Application.MemberManagement.Queries
{
    public record GetMembersQueryResult
    {
        public UserRoleEnums Role { get; init; } = null!;
        public MemberId MemberId { get; init; } = null!;
        public UserId UserId { get; init; } = null!;
        public Name Lastname { get; init; } = null!;
        public DateTime CreatedOn { get; init; }
        public Address? Address { get; init; }
        public Name? Firstname { get; init; }
        public Name? Nickname { get; init; }
        public Phone? Phone { get; init; }
    }
}
