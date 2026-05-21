namespace Project04.Application.Queries
{
    public class GetUserIdFromTokenQuery : ICommand<GetUserIdFromTokenQueryResult>
    {
        public string Token { get; private set; }

        public GetUserIdFromTokenQuery()
        {
        }

        public GetUserIdFromTokenQuery(string token)
            : this()
        {
            token.ValidateNotEmpty();

            Token = token;
        }
    }
}
