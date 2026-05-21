using Project04.Domain.ValueObjects;

namespace Project04.Domain.Entities
{
    public class BudgetEntity : BaseDescribeEntity<BudgetId>
    {
        public float Balance { get; private set; }
        public Period? Period { get; private set; }

        public BudgetEntity()
        {
        }

        public BudgetEntity(float balance = 0)
            : this()
        {
            Balance = balance;
        }

        public BudgetEntity ChangeDescription(string value)
        {
            value.ValidateNotEmpty();

            this.Description = value;

            return this;
        }

        public BudgetEntity ChangePeriod(Period value)
        {
            value.ValidateNotNull();

            this.Period = value;

            return this;
        }

        public BudgetEntity ChangeTitle(string value)
        {
            value.ValidateNotEmpty();

            this.Title = value;

            return this;
        }
    }
}
