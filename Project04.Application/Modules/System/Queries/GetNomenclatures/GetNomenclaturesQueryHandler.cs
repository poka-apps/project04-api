using Project04.Application.Providers;

namespace Project04.Application.Queries
{
    public class GetNomenclaturesQueryHandler : IRequestHandler<GetNomenclaturesQuery, IEnumerable<GetNomenclaturesQueryResult>>
    {
        private readonly ICountryProvider _countryProvider;

        public GetNomenclaturesQueryHandler(ICountryProvider countryProvider)
        {
            _countryProvider = countryProvider;
        }

        public async Task<IEnumerable<GetNomenclaturesQueryResult>> Handle(GetNomenclaturesQuery request, CancellationToken cancellationToken)
        {
            var result = new List<GetNomenclaturesQueryResult>();

            if (request.Type == NomenclatureEnums.Country)
            {
                result =    this._countryProvider
                                .GetCountries()
                                .OrderBy(l => l.name)
                                .Select(
                                    l => new GetNomenclaturesQueryResult
                                    {
                                        Id = l.codeIso2,
                                        Title = l.name
                                    }
                                )
                                .ToList();
            }
            else
            {
                throw new AppException(AppErrorEnums.NotImplemented, request.Type.Name);
            }

            return result;
        }
    }
}
