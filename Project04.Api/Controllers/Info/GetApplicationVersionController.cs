using Project04.Api.Infrastructure.Attributes;

namespace Project04.Api.Controllers.Info
{
    [ApiExplorerSettings(GroupName = "Informations")]
    [Produces(MediaTypeNames.Application.Json)]
    [ApiRoute("info/version")]
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

            var queryResult = await _mediator.Send(query, cancellationToken);

            var result = new GetApplicationVersionDTOResponse
            {
                EnvironmentName = queryResult.Environment.Name,
                Revision = queryResult.Revision,
                Build = queryResult.Build,
                Major = queryResult.Major,
                Minor = queryResult.Minor
            };

            return Ok(result);
        }
    }

    public class GetApplicationVersionDTOResponse
    {
        public string EnvironmentName { get; set; } = null!;
        public int Major { get; set; }
        public int Minor { get; set; }
        public int Build { get; set; }
        public int Revision { get; set; }
    }
}
