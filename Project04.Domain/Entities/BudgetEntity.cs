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

        public BudgetEntity AddTransaction(float amount)
        {
            this.Balance += amount;

            return this;
        }

        public BudgetEntity ChangePeriod(Period value)
        {
            value.ValidateNotNull();

            this.Period = value;

            return this;
        }
    }
}
