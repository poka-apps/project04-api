namespace Project04.Domain.Interfaces
{
    public interface IBaseIQuery
    {
    }

    public interface IQuery : IBaseIQuery, IRequest<Unit>
    {
    }

    public interface IQuery<TResponse> : IBaseIQuery, IRequest<TResponse>
    {
    }
}
