using Project04.Domain.ValueObjects;

namespace Project04.Domain.Entities
{
    public class TransactionEntity : BaseDescribeEntity<TransactionId>
    {
        public BudgetId BudgetId { get; private set; }
        public MemberId? MemberId { get; private set; }
        public float Amount { get; private set; }

        public TransactionEntity AssignToMember(MemberId memberId)
        {
            memberId.ValidateNotNull();

            this.MemberId = memberId;

            return this;
        }

        public TransactionEntity AssignToBudget(BudgetId budgetId)
        {
            budgetId.ValidateNotNull();

            this.BudgetId = budgetId;

            return this;
        }

        public TransactionEntity ChangeAmount(float amount) 
        {
            this.Amount = amount;

            return this;
        }
    }
}
