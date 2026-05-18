using Project04.Domain.ValueObjects;

namespace Project04.Domain.Entities
{
    public class BaseDescribeEntity<TObjectId, TValue> : BaseEntity<TObjectId, TValue>
        where TObjectId : BaseObjectId<TValue>
    {
        public string Title { get; private set; } = null!;
        public string? Description { get; private set; }
    }
}
