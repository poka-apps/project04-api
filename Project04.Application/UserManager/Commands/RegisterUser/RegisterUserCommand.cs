namespace Project04.Application.UserManager.Commands
{
    public class RegisterUserCommand : ICommand<RegisterUserCommandResult>
    {
        public Name Firstname { get; private set; } = null!;
        public Password? Password { get; private set; }
        public Email? Email { get; private set; }
        public Name? Lastname { get; private set; }
        public Name? Nickname { get; private set; }
        public UserRoleEnums? Role { get; private set; }
        public bool Root { get; private set; }

        public RegisterUserCommand()
        { }

        public RegisterUserCommand(
            Name firstname, 
            Name? lastname = null, 
            Name? nickname = null,
            Email? email = null, 
            Password? password = null, 
            UserRoleEnums? role = null, 
            bool root = false
        )
            : this()
        {
            firstname.ValidateNotNull();

            Firstname = firstname;
            Lastname = lastname;
            Nickname = nickname;
            Password = password;
            Email = email;
            Role = role;
            Root = root;
        }
    }
}
