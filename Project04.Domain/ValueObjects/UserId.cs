namespace Project04.Domain.ValueObjects
{
    public record UserId : BaseObjectId<Guid>
    {
        protected override string _type => "usr";

        public UserId(Guid value)
            : base(value)
        { }

        public override string ToString() => $"{this._type}_{this.Value}";
    }
}
