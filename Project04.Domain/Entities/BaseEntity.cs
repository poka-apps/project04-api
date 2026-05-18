using Project04.Domain.ValueObjects;

namespace Project04.Domain.Entities
{
    public abstract class BaseEntity<TObjectId>
        where TObjectId : BaseEntityId
    {
        public TObjectId Id { get; protected set; } = default!;
        public DateTime CreatedOn { get; protected set; }

        protected BaseEntity()
        {
            this.CreatedOn = DateTime.UtcNow;
        }
    }
}
