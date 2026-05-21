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
    }
}
