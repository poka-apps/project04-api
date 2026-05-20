using Project04.Api.Infrastructure.Attributes;
using Project04.Api.Infrastructure.DTOs;

namespace Project04.Api.Controllers.Account
{
    [ApiExplorerSettings(GroupName = "Account")]
    [Produces(MediaTypeNames.Application.Json)]
    [ApiRoute("account/login")]
    [ApiController]
    public class GenerateUserAccessTokenController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GenerateUserAccessTokenController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Authenticate user (Anonymous).
        /// </summary>
        /// <param name="bodyData"></param>
        /// <param name="cancellationToken"></param>
        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(typeof(TokenDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> Async([FromBody] GenerateUserAccessTokenDTORequest bodyData, CancellationToken cancellationToken)
        {
            var query = new GenerateUserAccessTokenCommand(
                            password: bodyData.Password.ToPassword(),
                            email: bodyData.Email.ToEmail()
                        );
            var queryResult = await _mediator.Send(query, cancellationToken);

            var result = new TokenDTO
            {
                ExpirationDate = queryResult.AccessToken.ExpirationDate!.Value,
                RefreshToken = queryResult.AccessToken.RefreshToken,
                AccessToken = queryResult.AccessToken.Value
            };

            return Ok(result);
        }
    }

    public class GenerateUserAccessTokenDTORequest
    {
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
