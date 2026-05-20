using Project04.Api.Infrastructure.Attributes;
using Project04.Application.MemberManagement.Queries;

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

        [AllowAnonymous]
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
                                    FirstName = l.FirstName.Value,
                                    LastName = l.LastName?.Value,
                                    UserId = l.UserId.ToString(),
                                    Id = l.MemberId.ToString(),
                                    CreatedOn = l.CreatedOn,
                                    Role = l.Role.Name
                                }
                            )
                            .ToArray();

            return Ok(result);
        }
    }

    public class GetMembersDTOResponse
    {
        public string Id { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string Role { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
