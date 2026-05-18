using Project04.Domain.ValueObjects;

namespace Project04.Domain.Interfaces
{
    public interface ICurrentUser
    {
        UserId? UserId { get; }
    }
}
