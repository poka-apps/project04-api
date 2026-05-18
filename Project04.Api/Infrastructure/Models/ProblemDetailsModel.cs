namespace Project04.Api.Infrastructure.Models
{
    public class ProblemDetailsModel : ProblemDetails
    {
        public new required IDictionary<string, object?> Extensions { get; set; }
        public AppErrorEnums Code { get; set; }
    }
}
