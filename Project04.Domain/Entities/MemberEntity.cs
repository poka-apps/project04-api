using Project04.Domain.ValueObjects;

namespace Project04.Domain.Entities
{
    public class MemberEntity : BaseEntity<MemberId>
    {
        public UserId UserId { get; private set; }

        public MemberEntity()
        { }

        public MemberEntity(UserId userId)
        {
            userId.ValidateNotNull();

            UserId = userId;
        }
    }
}
