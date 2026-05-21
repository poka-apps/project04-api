namespace Project04.Application.Queries
{
    public class GetNomenclaturesQuery : IQuery<IEnumerable<GetNomenclaturesQueryResult>>
    {
        public NomenclatureEnums Type { get; private set; }

        public GetNomenclaturesQuery()
        {
        }

        public GetNomenclaturesQuery(NomenclatureEnums type)
            : this()
        {
            type.ValidateNotNull();

            Type = type;
        }
    }
}
