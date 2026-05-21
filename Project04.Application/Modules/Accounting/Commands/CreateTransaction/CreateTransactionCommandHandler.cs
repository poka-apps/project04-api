using Project04.Application.Providers;
using Project04.Application.Repositories;

namespace Project04.Application.Accounting.Commands
{
    public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, CreateTransactionCommandResult>
    {
        private readonly ICurrentUserProvider _currentUserProvider;
        private readonly IDbRepository _dbRepository;

        public CreateTransactionCommandHandler(IDbRepository dbRepository, ICurrentUserProvider currentUserProvider)
        {
            _currentUserProvider = currentUserProvider;
            _dbRepository = dbRepository;
        }

        public async Task<CreateTransactionCommandResult> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {
            #region Get budget

            var budgetEntity =  await 
                                    this._dbRepository
                                        .Budgets
                                        .FirstOrDefaultAsync(
                                            l => l.Id == request.BudgetId, 
                                            cancellationToken
                                        );

            if (budgetEntity == null)
            {
                throw new AppException(AppErrorEnums.NotFoundBudget, request.BudgetId.ToString());
            }

            #endregion

            #region Create transaction

            var transactionEntity =  new TransactionEntity()
                                        .CreatedBy<TransactionEntity>(this._currentUserProvider.UserId)
                                        .ChangeTitle<TransactionEntity>(request.Title)
                                        .AssignToBudget(request.BudgetId)
                                        .ChangeAmount(request.Amount);

            if (request.Description != null)
            {
                transactionEntity.ChangeDescription<TransactionEntity>(request.Description);
            }

            if (request.MemberId != null)
            {
                transactionEntity.AssignToMember(request.MemberId);
            }

            await
                this._dbRepository
                    .Transactions
                    .AddAsync(
                        cancellationToken: cancellationToken,
                        entity: transactionEntity
                    );

            #endregion

            #region Update budget

            budgetEntity.AddTransaction(transactionEntity.Amount);

            #endregion

            await this._dbRepository.SaveChangesAsync(cancellationToken);

            var result = new CreateTransactionCommandResult
            {
                TransactionId = transactionEntity.Id
            };

            return result;
        }
    }
}
