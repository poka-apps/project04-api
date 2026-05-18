namespace Project04.Application.MemberManagement.Commands
{
    public class CreateMemberCommand : ICommand<CreateMemberCommandResult>
    {
        public Name FirstName { get; private set; } = null!;
        public Email? Email { get; private set; }
        public Name? LastName { get; private set; }

        public CreateMemberCommand()
        { }

        public CreateMemberCommand(
            Name firstName, 
            Name? lastName = null, 
            Email? email = null
        )
            : this()
        {
            firstName.ValidateNotNull();

            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
    }
}
