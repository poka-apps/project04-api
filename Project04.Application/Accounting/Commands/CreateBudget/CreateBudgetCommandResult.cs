namespace Project04.Application.Accounting.Commands
{
    public record CreateBudgetCommandResult
    {
        public BudgetId BudgetId { get; init; } = null!;
    }
}
