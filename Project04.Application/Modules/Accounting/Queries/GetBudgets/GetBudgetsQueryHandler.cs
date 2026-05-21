using Project04.Application.Repositories;

namespace Project04.Application.Accounting.Queries
{
    public class GetBudgetsQueryHandler : IRequestHandler<GetBudgetsQuery, IEnumerable<GetBudgetsQueryResult>>
    {
        private readonly IDbRepository _dbRepository;

        public GetBudgetsQueryHandler(IDbRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }

        public async Task<IEnumerable<GetBudgetsQueryResult>> Handle(GetBudgetsQuery request, CancellationToken cancellationToken)
        {
            var query = this._dbRepository
                            .Budgets
                            .AsQueryable()
                            .AsNoTracking();

            if (request.Period is not null)
            {
                query = query.Where(l => l.Period == request.Period);
            }

            var queryResult = await query.ToListAsync(cancellationToken);

            var result = queryResult
                            .Select(
                                l => new GetBudgetsQueryResult
                                {
                                    Description = l.Description,
                                    Balance = l.Balance,
                                    Period = l.Period,
                                    Title = l.Title,
                                    Id = l.Id
                                }
                            )
                            .ToList();

            return result;
        }
    }
}
