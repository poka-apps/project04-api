namespace Project04.Application.MemberManagement.Queries
{
    public record GetMembersQueryResult
    {
        public UserRoleEnums Role { get; init; } = null!;
        public MemberId MemberId { get; init; } = null!;
        public UserId UserId { get; init; } = null!;
        public Name FirstName { get; init; } = null!;
        public Name? LastName { get; init; }
        public Address? Address { get; set; }
        public DateTime CreatedOn { get; init; }
    }
}
