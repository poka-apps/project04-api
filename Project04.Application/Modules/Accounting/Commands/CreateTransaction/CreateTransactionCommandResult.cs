namespace Project04.Application.Accounting.Commands
{
    public record CreateTransactionCommandResult
    {
        public TransactionId TransactionId { get; init; } = null!;
    }
}
