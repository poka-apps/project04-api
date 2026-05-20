using Project04.Domain.Enums;
using Project04.Domain.ValueObjects;

namespace Project04.Domain.Entities
{
    public class UserEntity : BaseEntity<UserId>
    {
        public UserRoleEnums Role { get; private set; } = null!;
        public Name Firstname { get; private set; } = null!;
        public bool Root { get; private set; }

        public MemberId? MemberId { get; private set; }
        public Email? Email { get; private set; }
        public Name? Lastname { get; private set; }
        public Name? Nickname { get; private set; }
        public PasswordEncrypted? Password { get; private set; }

        public UserEntity()
        {
            this.Root = false;
            this.Role = UserRoleEnums.User;
        }

        public UserEntity EditProfile(
            Name firstName, 
            Name? nickname = null,
            Name? lastname = null
        )
        {
            firstName.ValidateNotNull();

            firstName.Humanize();
            lastname?.Humanize();
            nickname?.Humanize();

            this.Firstname = firstName;
            this.Lastname = lastname;
            this.Nickname = nickname;

            return this;
        }

        public UserEntity AttachToMember(MemberId memberId)
        {
            memberId.ValidateNotNull();

            this.MemberId = memberId;

            return this;
        }

        public UserEntity ChangePassword(Password password)
        {
            password.ValidateNotNull();

            this.Password = password.Encrypt();

            return this;
        }

        public UserEntity ChangeRole(UserRoleEnums role)
        {
            role.ValidateNotNull();

            this.Role = role;

            return this;
        }

        public UserEntity ChangeEmail(Email email)
        {
            email.ValidateNotNull();

            this.Email = email;

            return this;
        }

        public string GetFullName() => 
            $"{this.Firstname} {this.Lastname}".Trim();

        public UserEntity AsRoot()
        {
            this.Root = true;

            return this;
        }
    }
}
