using Project04.Application.Providers;
using Project04.Application.Repositories;
using Project04.Application.UserManager.Commands;

namespace Project04.Application.MemberManagement.Commands
{
    public class CreateMemberCommandHandler : IRequestHandler<CreateMemberCommand, CreateMemberCommandResult>
    {
        private readonly ICurrentUserProvider _currentUserProvider;
        private readonly IDbRepository _dbRepository;
        private readonly IMediator _mediator;

        public CreateMemberCommandHandler(IDbRepository dbRepository, ICurrentUserProvider currentUserProvider, IMediator mediator)
        {
            _currentUserProvider = currentUserProvider;
            _dbRepository = dbRepository;
            _mediator = mediator;
        }

        public async Task<CreateMemberCommandResult> Handle(CreateMemberCommand request, CancellationToken cancellationToken)
        {
            await this._dbRepository.BeginTransactionAsync(cancellationToken);

            #region Register user

            var registerUserCommand =   new RegisterUserCommand(
                                            firstname: request.Firstname,
                                            lastname: request.Lastname,
                                            nickname: request.Nickname,
                                            email: request.Email
                                        );

            var registerUserCommandResult = await this._mediator.Send(registerUserCommand, cancellationToken);

            #endregion

            #region Create member

            var memberEntity = new MemberEntity(userId: registerUserCommandResult.UserId)
                                    .CreatedBy<MemberEntity>(this._currentUserProvider.UserId);

            if (request.Address != null)
            {
                memberEntity.ChangeAddress(request.Address);
            }

            if (request.Phone != null)
            {
                memberEntity.ChangePhone(request.Phone);
            }

            await
                this._dbRepository
                    .Members
                    .AddAsync(
                        cancellationToken: cancellationToken,
                        entity: memberEntity
                    );

            await this._dbRepository.SaveChangesAsync(cancellationToken);

            #endregion

            #region Attach member to user

            var userEntity = await 
                                this._dbRepository
                                    .Users
                                    .FirstAsync(
                                        l => l.Id == registerUserCommandResult.UserId, 
                                        cancellationToken
                                    );

            userEntity.AttachToMember(memberEntity.Id);
            
            this._dbRepository.Members.Update(memberEntity);

            await this._dbRepository.SaveChangesAsync(cancellationToken);

            #endregion

            await this._dbRepository.CommitTransactionAsync(cancellationToken);

            var result = new CreateMemberCommandResult
            {
                UserId = registerUserCommandResult.UserId,
                MemberId = memberEntity.Id
            };

            return result;
        }
    }
}
