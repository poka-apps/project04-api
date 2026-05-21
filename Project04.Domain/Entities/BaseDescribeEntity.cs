using Project04.Domain.ValueObjects;

namespace Project04.Domain.Entities
{
    /// <summary>
    /// CLass with properties 'Title', 'Description?'.
    /// </summary>
    /// <typeparam name="TObjectId"></typeparam>
    public class BaseDescribeEntity<TObjectId> : BaseEntity<TObjectId>
        where TObjectId : BaseEntityId
    {
        public string Title { get; protected set; } = null!;
        public string? Description { get; protected set; }

        public TEntity ChangeDescription<TEntity>(string value)
            where TEntity : BaseDescribeEntity<TObjectId>
        {
            value.ValidateNotEmpty();

            this.Description = value;

            return (TEntity)this;
        }

        public TEntity ChangeTitle<TEntity>(string value)
            where TEntity : BaseDescribeEntity<TObjectId>
        {
            value.ValidateNotEmpty();

            this.Title = value;

            return (TEntity)this;
        }
    }
}
