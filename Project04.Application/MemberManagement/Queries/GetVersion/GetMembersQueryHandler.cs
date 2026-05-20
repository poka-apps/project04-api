using Project04.Application.Repositories;

namespace Project04.Application.MemberManagement.Queries
{
    public class GetMembersQueryHandler : IRequestHandler<GetMembersQuery, IEnumerable<GetMembersQueryResult>>
    {
        private readonly IDbRepository _dbRepository;

        public GetMembersQueryHandler(IDbRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }

        public async Task<IEnumerable<GetMembersQueryResult>> Handle(GetMembersQuery request, CancellationToken cancellationToken)
        {
            var queryMembers = this._dbRepository.Members.AsQueryable();
            var queryUsers = this._dbRepository.Users.AsQueryable();

            var query = from member in queryMembers
                        join user in queryUsers 
                            on member.UserId equals user.Id
                        select new
                        {
                            MemberId = member.Id,
                            UserId = user.Id,

                            member.CreatedOn,
                            user.Firstname,
                            user.Lastname,
                            user.Role
                        };

            var queryResult = await query.ToListAsync(cancellationToken);

            var result = queryResult
                            .Select(
                                l => new GetMembersQueryResult
                                {
                                    CreatedOn = l.CreatedOn,
                                    FirstName = l.Firstname,
                                    MemberId = l.MemberId,
                                    LastName = l.Lastname,
                                    UserId = l.UserId,
                                    Role = l.Role
                                }
                            )
                            .ToList();

            return result;
        }
    }
}
