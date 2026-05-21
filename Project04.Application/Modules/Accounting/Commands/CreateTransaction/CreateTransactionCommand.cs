namespace Project04.Application.Accounting.Commands
{
    public class CreateTransactionCommand : ICommand<CreateTransactionCommandResult>
    {
        public BudgetId BudgetId { get; private set; } = null!;
        public string Title { get; private set; } = null!;
        public float Amount { get; private set; }
        public string? Description { get; private set; }
        public MemberId? MemberId { get; private set; }

        public CreateTransactionCommand()
        { }

        public CreateTransactionCommand(
            BudgetId budgetId, 
            string title, 
            float amount,
            string? description = null, 
            MemberId? memberId = null
        )
        {
            budgetId.ValidateNotNull();
            title.ValidateNotNull();

            Description = description;
            MemberId = memberId;
            BudgetId = budgetId;
            Amount = amount;
            Title = title;
        }
    }
}
