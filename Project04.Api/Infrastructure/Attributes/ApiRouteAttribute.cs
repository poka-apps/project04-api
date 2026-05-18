namespace Project04.Api.Infrastructure.Attributes
{
    /// <summary>
    /// ...
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class ApiRouteAttribute : RouteAttribute
    {
        private static string BaseRoute => "api";

        /// <summary>
        /// Initializes a new instance of the ApiRouteAttribute class with the default base route.
        /// </summary>
        public ApiRouteAttribute()
            : base(BaseRoute)
        {
        }

        /// <summary>
        /// Initializes a new instance of the ApiRouteAttribute class with the specified route template.
        /// </summary>
        /// <remarks>Use this attribute to define custom routing for API controllers or actions. The
        /// provided template is appended to the base route unless it is null, empty, or consists only of
        /// whitespace.</remarks>
        /// <param name="template">The route template to associate with the API endpoint. If null, empty, or whitespace, the base route is
        /// used.</param>
        public ApiRouteAttribute(string template)
            : base(string.IsNullOrWhiteSpace(template) ? BaseRoute : $"{BaseRoute}/{template}")
        {
        }
    }
}
