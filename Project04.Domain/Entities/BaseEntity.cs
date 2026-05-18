using Project04.Domain.ValueObjects;

namespace Project04.Domain.Entities
{
    public abstract class BaseEntity<TObjectId, TValue> : BaseEntity
        where TObjectId : BaseObjectId<TValue>
    {
        public TObjectId Id { get; protected set; } = default!;
    }

    public abstract class BaseEntity
    {
        public DateTime CreatedOn { get; protected set; }

        protected BaseEntity()
        {
            this.CreatedOn = DateTime.UtcNow;
        }
    }
}
