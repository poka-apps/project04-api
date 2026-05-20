namespace Project04.Application.Commands
{
    public class GenerateUserAccessTokenCommand : ICommand<GenerateUserAccessTokenCommandResult>
    {
        public Email? Email { get; private set; }
        public Password? Password { get; private set; }
        public string? RefreshToken { get; private set; }

        public GenerateUserAccessTokenCommand()
        {
        }

        public GenerateUserAccessTokenCommand(Email? email = null, Password? password = null, string? refreshToken = null)
            : this()
        {
            RefreshToken = refreshToken;
            Password = password;
            Email = email;
        }
    }
}
