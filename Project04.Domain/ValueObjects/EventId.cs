namespace Project04.Domain.ValueObjects
{
    public record EventId : BaseEntityId
    {
        protected override string _type => "evt";

        public EventId(Guid value)
            : base(value)
        { }

        public override string ToString() => $"{this._type}_{this.Value}";
    }
}
