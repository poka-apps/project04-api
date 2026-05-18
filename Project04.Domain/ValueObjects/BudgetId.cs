namespace Project04.Domain.ValueObjects
{
    public record BudgetId : BaseObjectId<Guid>
    {
        protected override string _type => "bud";

        public BudgetId(Guid value)
            : base(value)
        { }

        public override string ToString() => $"{this._type}_{this.Value}";
    }
}
