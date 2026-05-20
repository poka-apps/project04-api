using Project04.Domain.ValueObjects;

namespace Project04.Domain.Entities
{
    public class MemberEntity : BaseEntity<MemberId>
    {
        public UserId UserId { get; private set; }
        public Address? Address { get; private set; }
        public Phone? Phone { get; private set; }

        public MemberEntity()
        { }

        public MemberEntity(UserId userId)
        {
            userId.ValidateNotNull();

            UserId = userId;
        }

        public MemberEntity ChangeAddress(Address? value = null)
        {
            this.Address = value;

            return this;
        }

        public MemberEntity ChangePhone(Phone? value = null)
        {
            this.Phone = value;

            return this;
        }
    }
}
