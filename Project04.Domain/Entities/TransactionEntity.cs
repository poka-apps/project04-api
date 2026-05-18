using Project04.Domain.ValueObjects;

namespace Project04.Domain.Entities
{
    public class TransactionEntity : BaseDescribeEntity<TransactionId>
    {
        public BudgetId BudgetId { get; private set; }
        public MemberId? MemberId { get; private set; }
        public float Amount { get; private set; }
    }
}
