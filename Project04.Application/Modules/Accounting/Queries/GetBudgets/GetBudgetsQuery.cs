namespace Project04.Application.Accounting.Queries
{
    public class GetBudgetsQuery : IQuery<IEnumerable<GetBudgetsQueryResult>>
    {
        public Period? Period { get; private set; }

        public GetBudgetsQuery()
        {
        }

        public GetBudgetsQuery(Period? period = null)
            : this()
        {
            Period = period;
        }
    }
}
