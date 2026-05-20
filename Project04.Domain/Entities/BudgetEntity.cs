using Project04.Domain.ValueObjects;

namespace Project04.Domain.Entities
{
    public class BudgetEntity : BaseDescribeEntity<BudgetId>
    {
        public Period? Period { get; private set; }
    }
}
