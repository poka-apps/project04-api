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
                                password: bodyData.Password?.ToPassword(),
                                firstname: bodyData.Firstname?.ToName(),
                                role: bodyData.Role?.ToUserRoleEnums(),
                                nickname: bodyData.Nickname?.ToName(),
                                lastname: bodyData.Lastname.ToName(),
                                email: bodyData.Email?.ToEmail()
                            );

            var commandResult = await this._mediator.Send(command, cancellationToken);

            var result = commandResult.UserId.ToString();

            return Ok(result);
        }
    }

    public class RegisterUserDTORequest
    {
        public string Lastname { get; set; } = null!;
        public string? Firstname { get; set; }
        public string? Nickname { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; }
    }
}
