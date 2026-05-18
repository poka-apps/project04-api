namespace Project04.Domain.Enums
{
    public sealed class UserRoleEnums : BaseEnums<UserRoleEnums>
    {
        public static readonly UserRoleEnums Administrator = new(0, "Administrator");
        public static readonly UserRoleEnums User = new(1, "User");

        public UserRoleEnums(int value, string name)
            : base(value, name)
        { }
    }
}
