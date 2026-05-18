using Project04.Application.Providers;

namespace Project04.Application.Queries
{
    public class GetVersionQueryHandler : IRequestHandler<GetVersionQuery, GetVersionQueryResult>
    {
        private readonly IAppSettingsProvider _appSettingsProvider;

        public GetVersionQueryHandler(IAppSettingsProvider appSettingsProvider)
        {
            _appSettingsProvider = appSettingsProvider;
        }

        public Task<GetVersionQueryResult> Handle(GetVersionQuery request, CancellationToken cancellationToken)
        {
            var version = GetType().Assembly.GetName().Version!;

            var result = new GetVersionQueryResult
            {
                Environment = _appSettingsProvider.Environment,
                Revision = version.Revision,
                Build = version.Build,
                Major = version.Major,
                Minor = version.Minor
            };

            return Task.FromResult(result);
        }
    }
}
