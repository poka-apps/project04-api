namespace Project04.Domain.ValueObjects
{
    public abstract record BaseEntityId : BaseObjectId<Guid>
    {
        protected BaseEntityId(Guid original) 
            : base(original)
        {
        }
    }
}
