namespace Project04.Application.MemberManagement.Commands
{
    public class CreateMemberCommand : ICommand<CreateMemberCommandResult>
    {
        public Name FirstName { get; private set; } = null!;
        public Password? Password { get; private set; }
        public Email? Email { get; private set; }
        public Name? LastName { get; private set; }
        public UserRoleEnums? Role { get; private set; }
        public bool Root { get; private set; }

        public CreateMemberCommand()
        { }

        public CreateMemberCommand(
            Name firstName, 
            Name? lastName = null, 
            Email? email = null, 
            Password? password = null, 
            UserRoleEnums? role = null, 
            bool root = false
        )
            : this()
        {
            firstName.ValidateNotNull();

            FirstName = firstName;
            LastName = lastName;
            Password = password;
            Email = email;
            Role = role;
            Root = root;
        }
    }
}
