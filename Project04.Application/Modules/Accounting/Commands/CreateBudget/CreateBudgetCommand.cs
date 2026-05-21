namespace Project04.Application.Accounting.Commands
{
    public class CreateBudgetCommand : ICommand<CreateBudgetCommandResult>
    {
        public string Title { get; private set; } = null!;
        public string? Description { get; private set; }
        public float Balance { get; private set; }
        public Period? Period { get; private set; }

        public CreateBudgetCommand()
        { }

        public CreateBudgetCommand(
            string title,
            string? description = null,
            float balance = 0,
            Period? period = null
        )
            : this()
        {
            title.ValidateNotEmpty();

            Description = description;
            Balance = balance;
            Period = period;
            Title = title;
        }
    }
}
