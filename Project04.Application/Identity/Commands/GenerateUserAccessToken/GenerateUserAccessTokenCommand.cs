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

        public GenerateUserAccessTokenCommand(string refreshToken)
        {
            refreshToken.ValidateHasValue();

            RefreshToken = refreshToken;
        }

        public GenerateUserAccessTokenCommand(Email email, Password password)
        {
            password.ValidateNotNull();
            email.ValidateNotNull();

            Email = email;
            Password = password;
        }
    }
}
