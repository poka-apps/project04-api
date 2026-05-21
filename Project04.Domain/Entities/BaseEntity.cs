using Project04.Domain.ValueObjects;

namespace Project04.Domain.Entities
{
    /// <summary>
    /// Class with properties 'Id', 'CreatedOn'.
    /// </summary>
    /// <typeparam name="TObjectId"></typeparam>
    public abstract class BaseEntity<TObjectId>
        where TObjectId : BaseEntityId
    {
        public TObjectId Id { get; protected set; } = default!;
        public UserId? CreatedByUserId { get; protected set; }        
        public DateTime CreatedOn { get; protected set; }

        protected BaseEntity()
        {
            this.CreatedOn = DateTime.UtcNow;
        }

        public TEntity CreatedBy<TEntity>(UserId? value)
            where TEntity : BaseEntity<TObjectId>
        {
            this.CreatedByUserId = value;

            return (TEntity)this;
        }
    }
}
