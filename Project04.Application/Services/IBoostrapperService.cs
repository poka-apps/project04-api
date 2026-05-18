namespace Project04.Application.Services
{
    public interface IBoostrapperService
    {
        Task StartAsync(CancellationToken cancellationToken = default);
    }
}
