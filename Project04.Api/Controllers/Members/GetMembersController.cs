using Project04.Api.Infrastructure.Attributes;
using Project04.Application.MemberManagement.Queries;
using Project04.Domain.ValueObjects;

namespace Project04.Api.Controllers.Members
{
    [ApiExplorerSettings(GroupName = "Members")]
    [Produces(MediaTypeNames.Application.Json)]
    [ApiRoute("members")]
    [ApiController]
    public class GetMembersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GetMembersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(GetMembersDTOResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Async(CancellationToken cancellationToken)
        {
            var query = new GetMembersQuery();

            var queryResult = await this._mediator.Send(query, cancellationToken);

            var result = queryResult
                            .Select(
                                l => new GetMembersDTOResponse
                                {
                                    Firstname = l.Firstname.Value,
                                    Lastname = l.Lastname?.Value,
                                    Nickname = l.Nickname?.Value,
                                    UserId = l.UserId.ToString(),
                                    Id = l.MemberId.ToString(),
                                    CreatedOn = l.CreatedOn,
                                    Address = l.Address,
                                    Role = l.Role.Name
                                }
                            )
                            .ToArray();

            return Ok(result);
        }
    }

    public class GetMembersDTOResponse
    {
        public string Firstname { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public string Role { get; set; } = null!;
        public string Id { get; set; } = null!;
        public string? Lastname { get; set; }
        public string? Nickname { get; set; }
        public Address? Address { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
