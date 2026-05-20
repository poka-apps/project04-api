using Project04.Domain.ValueObjects;

namespace Project04.Domain.Entities
{
    public class EventEntity : BaseDescribeEntity<EventId>
    {
        public BudgetId? BudgetId { get; private set; }
        public DateTime On { get; private set; }
    }
}
