namespace Project04.Domain.Enums
{
    public sealed class EnvironmentEnums : BaseEnums<EnvironmentEnums>
    {
        public static readonly EnvironmentEnums Development = new(0, "Development");
        public static readonly EnvironmentEnums Staging = new(1, "Staging");
        public static readonly EnvironmentEnums Production = new(2, "Production");
        public static readonly EnvironmentEnums Test = new(3, "Test");

        public EnvironmentEnums(int value, string name)
            : base(value, name)
        {
        }
    }
}
