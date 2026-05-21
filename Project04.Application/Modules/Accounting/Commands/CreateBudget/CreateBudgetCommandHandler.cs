using Project04.Application.Providers;
using Project04.Application.Repositories;

namespace Project04.Application.Accounting.Commands
{
    public class CreateBudgetCommandHandler : IRequestHandler<CreateBudgetCommand, CreateBudgetCommandResult>
    {
        private readonly ICurrentUserProvider _currentUserProvider;
        private readonly IDbRepository _dbRepository;

        public CreateBudgetCommandHandler(IDbRepository dbRepository, ICurrentUserProvider currentUserProvider)
        {
            _currentUserProvider = currentUserProvider;
            _dbRepository = dbRepository;
        }

        public async Task<CreateBudgetCommandResult> Handle(CreateBudgetCommand request, CancellationToken cancellationToken)
        {
            var budgetEntity =  new BudgetEntity(request.Balance)
                                    .CreatedBy<BudgetEntity>(this._currentUserProvider.UserId)
                                    .ChangeTitle<BudgetEntity>(request.Title);

            if (request.Description != null)
            {
                budgetEntity.ChangeDescription<BudgetEntity>(request.Description);
            }

            if (request.Period != null)
            {
                budgetEntity.ChangePeriod(request.Period);
            }

            await
                this._dbRepository
                    .Budgets
                    .AddAsync(
                        cancellationToken: cancellationToken,
                        entity: budgetEntity
                    );

            await this._dbRepository.SaveChangesAsync(cancellationToken);

            var result = new CreateBudgetCommandResult
            {
                BudgetId = budgetEntity.Id
            };

            return result;
        }
    }
}
