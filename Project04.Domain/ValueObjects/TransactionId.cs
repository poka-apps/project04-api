namespace Project04.Domain.ValueObjects
{
    public record TransactionId : BaseObjectId<Guid>
    {
        protected override string _type => "txn";

        public TransactionId(Guid value)
            : base(value)
        { }

        public override string ToString() => $"{this._type}_{this.Value}";
    }
}
