namespace Project04.Application.Accounting.Queries
{
    public record GetBudgetsQueryResult
    {
        public BudgetId Id { get; init; } = null!;
        public string Title { get; init; } = null!;
        public string? Description { get; init; }
        public float Balance { get; init; }
        public Period? Period { get; init; }
    }
}
