using Project04.Application.Repositories;

namespace Project04.Application.UserManager.Commands
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, RegisterUserCommandResult>
    {
        private readonly IDbRepository _dbRepository;

        public RegisterUserCommandHandler(IDbRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }

        public async Task<RegisterUserCommandResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            #region Validations

            if (request.Email != null)
            {
                var doesEmailTaken = await
                                        this._dbRepository
                                            .Users
                                            .AnyAsync(
                                                l => l.Email == request.Email,
                                                cancellationToken
                                            );

                if (doesEmailTaken)
                {
                    throw new AppException(AppErrorEnums.ConflictUserEmailTaken, request.Email);
                }
            }

            if (request.Root)
            {
                var doesRootUserExist = await
                                            this._dbRepository
                                                .Users
                                                .AnyAsync(
                                                    l => l.Root,
                                                    cancellationToken
                                                );
                if (doesRootUserExist)
                {
                    throw new AppException(AppErrorEnums.ConflictRootUserAlreadyExist);
                }
            }

            #endregion

            var userEntity = new UserEntity()
                                .EditProfile(
                                    firstName: request.FirstName, 
                                    lastName: request.LastName
                                );

            if (request.Password != null)
            {
                userEntity.ChangePassword(request.Password);
            }

            if (request.Email != null)
            {
                userEntity.ChangeEmail(request.Email);
            }

            if (request.Role != null)
            {
                userEntity.ChangeRole(request.Role);
            }

            if (request.Root)
            {
                userEntity.AsRoot();
            }

            await 
                this._dbRepository
                    .Users
                    .AddAsync(
                        cancellationToken: cancellationToken,
                        entity: userEntity
                    );

            await this._dbRepository.SaveChangesAsync(cancellationToken);

            var result = new RegisterUserCommandResult
            {
                UserId = userEntity.Id
            };

            return result;
        }
    }
}
