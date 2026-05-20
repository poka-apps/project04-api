namespace Project04.Application.MemberManagement.Queries
{
    public record GetMembersQueryResult
    {
        public UserRoleEnums Role { get; init; }
        public MemberId MemberId { get; init; }
        public UserId UserId { get; init; }
        public Name FirstName { get; init; }
        public Name? LastName { get; init; }
        public DateTime CreatedOn { get; init; }
    }
}
