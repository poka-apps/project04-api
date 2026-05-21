using Project04.Application.Providers;

namespace Project04.Application.Queries
{
    public class GetUserIdFromTokenQueryHandler : IRequestHandler<GetUserIdFromTokenQuery, GetUserIdFromTokenQueryResult>
    {
        private readonly IAppSettingsProvider _appSettingsProvider;

        public GetUserIdFromTokenQueryHandler(IAppSettingsProvider appSettingsProvider)
        {
            _appSettingsProvider = appSettingsProvider;
        }

        public async Task<GetUserIdFromTokenQueryResult> Handle(GetUserIdFromTokenQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var claimsPrincipal = new JwtSecurityTokenHandler()
                                            .ValidateToken(
                                                validationParameters: this._appSettingsProvider.GetTokenValidationParameters(),
                                                validatedToken: out _,
                                                token: request.Token
                                            );

                var userId = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier);

                var result = new GetUserIdFromTokenQueryResult
                {
                    UserId = userId!.Value.ToBaseEntityId<UserId>()
                };

                return result;
            }
            catch (Exception ex)
            {
                throw
                    new AppException(
                        codeError: AppErrorEnums.UnauthorizedInvalidAccessToken,
                        data: request.Token,
                        cause: ex
                    );
            }
        }
    }
}
