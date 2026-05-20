using Project04.Api.Infrastructure.Attributes;

namespace Project04.Api.Controllers.Info
{
    [ApiExplorerSettings(GroupName = "Health")]
    [Produces(MediaTypeNames.Application.Json)]
    [ApiRoute("health")]
    [ApiController]
    public class GetApplicationVersionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GetApplicationVersionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(typeof(GetApplicationVersionDTOResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Async(CancellationToken cancellationToken)
        {
            var query = new GetVersionQuery();

            var queryResult = await this._mediator.Send(query, cancellationToken);

            var result = new GetApplicationVersionDTOResponse
            {
                EnvironmentName = queryResult.Environment.Name,
                Version = queryResult.Version
            };

            return Ok(result);
        }
    }

    public class GetApplicationVersionDTOResponse
    {
        public string EnvironmentName { get; set; } = null!;
        public Version Version { get; set; } = null!;
    }
}
