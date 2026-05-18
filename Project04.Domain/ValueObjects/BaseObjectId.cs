using Project04.Domain.Interfaces;

namespace Project04.Domain.ValueObjects
{
    public abstract record BaseObjectId<TValue> : IObjectId<TValue>
    {
        protected virtual string _type { get; } = null!;

        public TValue Value { get; private set; }

        public BaseObjectId(TValue value)
        {
            Value = value;
        }

        public static TObjectId Create<TObjectId, TValue2>(TValue2 fromValue)
            where TObjectId : class, IObjectId<TValue2> =>
            (TObjectId)Activator.CreateInstance(typeof(TObjectId), fromValue)!;

        public static TObjectId GenerateString<TObjectId>()
            where TObjectId : BaseObjectId<string>
        {
            var options = new ShortIdOptions(useNumbers: true, useSpecialCharacters: false, 16);
            var value = ShortId.Generate(options);

            return Create<TObjectId, string>(value);
        }

        public static TObjectId GenerateGuid<TObjectId>()
            where TObjectId : BaseObjectId<Guid> =>
            Create<TObjectId, Guid>(Guid.NewGuid());

        public string GetType_() =>
            this._type;
    }
}
