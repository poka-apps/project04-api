using System.Security.Claims;

namespace Project04.Api.Infrastructure.Providers
{
    public class CurrentUserProvider : ICurrentUserProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public UserId? UserId => GetValues(ClaimTypes.NameIdentifier, true)
                                    .FirstOrDefault()?
                                    .ToObjectId<UserId, Guid>();

        public bool IsAuthenticated => this._httpContextAccessor
                                            .HttpContext!
                                            .User
                                            .Identity!
                                            .IsAuthenticated;

        private string[] GetValues(string claimType, bool skipNotFoundException = false)
        {
            var values = this._httpContextAccessor
                                .HttpContext?
                                .User?
                                .Claims
                                .Where(l => l.Type == claimType)
                                .Select(l => l.Value)
                                .ToArray() ?? [];

            if (!skipNotFoundException && !values.Any())
            {
                return [];
            }

            return values;
        }
    }
}
