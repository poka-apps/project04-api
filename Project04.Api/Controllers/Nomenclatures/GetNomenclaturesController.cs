using Project04.Api.Infrastructure.Attributes;

namespace Project04.Api.Controllers
{
    [ApiExplorerSettings(GroupName = "Nomenclatures")]
    [Produces(MediaTypeNames.Application.Json)]
    [ApiRoute("nomenclatures/{type}")]
    [ApiController]
    public class GetNomenclaturesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GetNomenclaturesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(GetNomenclaturesDTOResponse[]), StatusCodes.Status200OK)]
        public async Task<IActionResult> Async([FromRoute] string type, CancellationToken cancellationToken)
        {
            var query = new GetNomenclaturesQuery(
                            type: NomenclatureEnums.FromValue(type)
                        );
            var queryResult = await this._mediator.Send(query, cancellationToken);

            var result = queryResult
                            .Select(
                                l => new GetNomenclaturesDTOResponse
                                {
                                    Title = l.Title,
                                    Data = l.Data,
                                    Id = l.Id
                                }
                            )
                            .ToArray();

            return Ok(result);
        }

        public class GetNomenclaturesDTOResponse
        {
            public object Id { get; set; } = null!;
            public string Title { get; set; } = null!;
            public object? Data { get; set; }
        }
    }
}
