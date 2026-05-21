namespace Project04.Domain.Enums
{
    public sealed class NomenclatureEnums : BaseEnums<NomenclatureEnums>
    {
        public static readonly NomenclatureEnums Country = new(0, "Country");

        public NomenclatureEnums(int value, string name)
            : base(value, name)
        {
        }
    }
}
