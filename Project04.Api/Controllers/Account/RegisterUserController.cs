using Project04.Api.Infrastructure.Attributes;

namespace Project04.Api.Controllers.Account
{
    [ApiExplorerSettings(GroupName = "Account")]
    [Produces(MediaTypeNames.Application.Json)]
    [ApiRoute("account/register")]
    [ApiController]
    public partial class RegisterUserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RegisterUserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public async Task<IActionResult> Async([FromBody] RegisterUserDTORequest bodyData, CancellationToken cancellationToken)
        {
            var command =   new RegisterUserCommand(
                                firstName: bodyData.FirstName.ToName(),
                                lastName: bodyData.LastName?.ToName()
                            );

            var commandResult = await _mediator.Send(command, cancellationToken);
            var result = commandResult.UserId.ToString();

            return Ok(result);
        }
    }

    public class RegisterUserDTORequest
    {
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }
    }
}
