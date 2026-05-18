namespace Project04.Domain.Interfaces
{
    public interface IObjectId<TValue>
    {
        TValue Value { get; }
        string GetType_();
    }
}
