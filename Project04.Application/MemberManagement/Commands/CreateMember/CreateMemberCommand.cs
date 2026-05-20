namespace Project04.Application.MemberManagement.Commands
{
    public class CreateMemberCommand : ICommand<CreateMemberCommandResult>
    {
        public Name FirstName { get; private set; } = null!;
        public Address? Address { get; private set; }
        public Name? LastName { get; private set; }
        public Email? Email { get; private set; }
        public Phone? Phone { get; private set; }

        public CreateMemberCommand()
        { }

        public CreateMemberCommand(
            Name firstName, 
            Name? lastName = null,
            Address? address = null,
            Phone? phone = null,
            Email? email = null
        )
            : this()
        {
            firstName.ValidateNotNull();

            FirstName = firstName;
            LastName = lastName;
            Address = address;
            Email = email;
            Phone = phone;
        }
    }
}
