namespace Project04.Domain.ValueObjects
{
    public record MemberId : BaseEntityId
    {
        protected override string _type => "mem";

        public MemberId(Guid value)
            : base(value)
        { }

        public override string ToString() => $"{this._type}_{this.Value}";
    }
}
