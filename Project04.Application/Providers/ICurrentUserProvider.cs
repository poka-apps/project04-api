namespace Project04.Application.Providers
{
    public interface ICurrentUserProvider : ICurrentUser
    {
        bool IsAuthenticated { get; }
    }
}
