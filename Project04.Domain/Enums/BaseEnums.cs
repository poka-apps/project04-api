namespace Project04.Domain.Enums
{
    public abstract class BaseEnums<TEnum> : IEquatable<BaseEnums<TEnum>>
        where TEnum : BaseEnums<TEnum>
    {
        private static readonly Dictionary<int, TEnum> _enumerations = CreateEnumerations();

        public int Value { get; protected init; }
        public string Name { get; protected init; } = string.Empty;

        protected BaseEnums(int value, string name)
        {
            Value = value;
            Name = name;
        }

        public static TEnum FromValue(int value)
        {
            var result = _enumerations.TryGetValue(value, out TEnum? enumValue)
                            ? enumValue
                            : default;

            if (result == default)
            {
                throw new AppException(
                            AppErrorEnums.InvalidValueExpected,
                            value.ToString(),
                            GetEnumValues()
                                .Select(l => l.Value.ToString())
                                .ToArray()
                        );
            }

            return result;
        }

        public static TEnum FromValue(string name)
        {
            var result = _enumerations.Values.FirstOrDefault(l => l.Name.ToLower().Trim() == name.ToLower().Trim());

            if (result == default)
            {
                throw new AppException(
                            AppErrorEnums.InvalidValueExpected,
                            typeof(TEnum).Name,
                            name,
                            GetEnumValues()
                                .Select(l => l.Name)
                                .ToArray()
                        );
            }

            return result;
        }

        public static Dictionary<int, TEnum> CreateEnumerations()
        {
            var type = typeof(TEnum);
            var fields = type
                            .GetFields(
                                BindingFlags.Public |
                                BindingFlags.Static |
                                BindingFlags.FlattenHierarchy
                            )
                            .Where(l => type.IsAssignableFrom(l.FieldType))
                            .Select(l => (TEnum)l.GetValue(default)!);

            return fields.ToDictionary(l => l.Value);
        }

        public static TEnum[] GetEnumValues()
        {
            var result = CreateEnumerations()
                            .Select(l => l.Value)
                            .ToArray();

            return result;
        }

        public bool Equals(BaseEnums<TEnum>? other)
        {
            if (other == null)
            {
                return false;
            }

            var isEqual = GetType() == other.GetType() && Value == other.Value;

            return isEqual;
        }

        public override bool Equals(object? obj)
        {
            var isEqual = obj is BaseEnums<TEnum> other && Equals(other);

            return isEqual;
        }

        public override int GetHashCode() => base.GetHashCode();

        public override string ToString() => $"({Value}) {Name}";
    }
}
