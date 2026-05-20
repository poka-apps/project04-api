namespace Project04.Application.MemberManagement.Commands
{
    public class CreateMemberCommand : ICommand<CreateMemberCommandResult>
    {
        public Name Firstname { get; private set; } = null!;
        public Address? Address { get; private set; }
        public Name? Lastname { get; private set; }
        public Name? Nickname { get; private set; }
        public Email? Email { get; private set; }
        public Phone? Phone { get; private set; }

        public CreateMemberCommand()
        { }

        public CreateMemberCommand(
            Name firstName, 
            Name? lastname = null,
            Name? nickname = null,
            Address? address = null,
            Phone? phone = null,
            Email? email = null
        )
            : this()
        {
            firstName.ValidateNotNull();

            Firstname = firstName;
            Lastname = lastname;
            Nickname = nickname;
            Address = address;
            Email = email;
            Phone = phone;
        }
    }
}
