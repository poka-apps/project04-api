using Project04.Application.Providers;
using Project04.Application.Queries;
using Project04.Application.Repositories;

namespace Project04.Application.Commands
{
    public class GenerateUserAccessTokenCommandHandler : IRequestHandler<GenerateUserAccessTokenCommand, GenerateUserAccessTokenCommandResult>
    {
        private readonly IAppSettingsProvider _appSettingsProvider;
        private readonly IDbRepository _dbRepository;
        private readonly IMediator _mediator;

        public GenerateUserAccessTokenCommandHandler(
            IAppSettingsProvider appSettingsProvider,
            IDbRepository dbRepository,
            IMediator mediator
        )
        {
            _appSettingsProvider = appSettingsProvider;
            _dbRepository = dbRepository;
            _mediator = mediator;
        }

        public async Task<GenerateUserAccessTokenCommandResult> Handle(GenerateUserAccessTokenCommand request, CancellationToken cancellationToken)
        {
            var userEntity = default(UserEntity);

            if (request.Email != null && request.Password != null)
            {
                userEntity = await 
                                this._dbRepository
                                    .Users
                                    .FirstOrDefaultAsync(
                                        l => l.Email == request.Email, 
                                        cancellationToken
                                    );

                if (userEntity == null)
                {
                    throw new AppException(AppErrorEnums.UnauthorizedInvalidEmailOrPassword, request.Email!.ToString(), request.Password!.ToString());
                }

                var isPasswordValid = request.Password!.IsValid(userEntity.Password!);

                if (isPasswordValid == false)
                {
                    throw new AppException(AppErrorEnums.UnauthorizedInvalidEmailOrPassword, request.Email!.ToString(), request.Password!.ToString());
                }
            }
            else if (request.RefreshToken != null)
            {
                var getUserIdFromToken = new GetUserIdFromTokenQuery(request.RefreshToken);
                var getUserIdFromTokenResult = await this._mediator.Send(getUserIdFromToken, cancellationToken);

                userEntity = await 
                                this._dbRepository
                                    .Users
                                    .FirstOrDefaultAsync(
                                        l => l.Id == getUserIdFromTokenResult.UserId, 
                                        cancellationToken
                                    );

                if (userEntity == null)
                {
                    throw new AppException(AppErrorEnums.UnauthorizedUserNotFound, getUserIdFromTokenResult.UserId.ToString());
                }
            }
            else
            {
                throw new AppException(AppErrorEnums.NotImplemented);
            }

            var accessToken = GenerateAccessToken(userEntity!);

            var result = new GenerateUserAccessTokenCommandResult
            {
                AccessToken = accessToken
            };

            return result;
        }

        #region Private

        private AccessToken GenerateAccessToken(UserEntity userEntity)
        {
            var dateTimeUtcNow = DateTime.UtcNow;
            var symmetricSecurityKey = new SymmetricSecurityKey(this._appSettingsProvider.Jwt.secret.ToUTF8Bytes());
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);
            var accessTokenExpirationDate = dateTimeUtcNow.AddSeconds(this._appSettingsProvider.Jwt.accessTokenLifetime);

            var accessToken = default(string);
            {
                var accessTokenClaims = new List<Claim>
                {
                    new(ClaimTypes.Expiration, accessTokenExpirationDate.ToString("O")),
                    new(ClaimTypes.Authentication, dateTimeUtcNow.ToString("O")),
                    new(ClaimTypes.NameIdentifier, userEntity.Id.ToString()),
                    new(ClaimTypes.Name, userEntity.GetFullName()),
                    new(ClaimTypes.Role, userEntity.Role.Name)
                };

                if (userEntity.Email != null)
                {
                    accessTokenClaims.Add(new Claim(ClaimTypes.Email, userEntity.Email.ToString()));
                }

                var jwtSecurityToken =  new JwtSecurityToken(
                                            audience: this._appSettingsProvider.Jwt.audience,
                                            issuer: this._appSettingsProvider.Jwt.issuer,
                                            signingCredentials: signingCredentials,
                                            expires: accessTokenExpirationDate,
                                            claims: accessTokenClaims
                                        );

                accessToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            }

            var refreshToken = default(string);
            {
                var refreshTokenExpirationDate = dateTimeUtcNow.AddSeconds(this._appSettingsProvider.Jwt.refreshTokenLifetime);
                var refreshTokenClaims = new List<Claim>
                {
                    new(ClaimTypes.Expiration, refreshTokenExpirationDate.ToString("O")),
                    new(ClaimTypes.NameIdentifier, userEntity.Id.ToString())
                };

                var jwtSecurityToken = new JwtSecurityToken(
                                            audience: this._appSettingsProvider.Jwt.audience,
                                            issuer: this._appSettingsProvider.Jwt.issuer,
                                            signingCredentials: signingCredentials,
                                            expires: refreshTokenExpirationDate,
                                            claims: refreshTokenClaims
                                        );

                refreshToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            }

            var result =    new AccessToken(
                                value: accessToken, 
                                refreshToken: refreshToken, 
                                expirationDate: accessTokenExpirationDate
                            );

            return result;
        }

        #endregion
    }
}
