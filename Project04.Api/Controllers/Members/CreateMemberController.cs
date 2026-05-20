using Project04.Api.Infrastructure.Attributes;
using Project04.Api.Infrastructure.DTOs;
using Project04.Application.MemberManagement.Commands;

namespace Project04.Api.Controllers.Members
{
    [ApiExplorerSettings(GroupName = "Members")]
    [Produces(MediaTypeNames.Application.Json)]
    [ApiRoute("members")]
    [ApiController]
    public partial class CreateMemberController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CreateMemberController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public async Task<IActionResult> Async([FromBody] CreateMemberDTORequest bodyData, CancellationToken cancellationToken)
        {
            var command =   new CreateMemberCommand(
                                address: bodyData.Address?.GetAddress(),
                                firstName: bodyData.FirstName.ToName(),
                                lastName: bodyData.LastName?.ToName(),
                                phone: bodyData.Phone?.GetPhone(),
                                email: bodyData.Email?.ToEmail()
                            );

            var commandResult = await this._mediator.Send(command, cancellationToken);

            var result = commandResult.MemberId.ToString();

            return Ok(result);
        }
    }

    public class CreateMemberDTORequest
    {
        public string FirstName { get; set; } = null!;
        public AddressDTO? Address { get; set; }
        public PhoneDTO? Phone { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
    }
}
