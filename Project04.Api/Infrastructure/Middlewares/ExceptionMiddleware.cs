using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.Localization;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Project04.Api.Infrastructure.Models;
using Project04.Domain.Resources.I18n;
using System.Reflection;
using ValidationException = FluentValidation.ValidationException;

namespace Project04.Api.Infrastructure.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private Type[] _typesWithInnerException => new[] {
                                                        typeof(TargetInvocationException)
                                                    };
        public static readonly JsonSerializerSettings DefaultJsonSerializerSettings = new()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        public ExceptionMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task InvokeAsync(
            HttpContext httpContext,
            IHostEnvironment hostEnvironment,
            IStringLocalizer<StringsLocalizedEnums> stringsLocalizedEnums,
            ILogger<ExceptionMiddleware> logger
        )
        {
            var exception = httpContext.Features.Get<IExceptionHandlerFeature>()!.Error!;

            logger.LogError(exception, exception.Message);

            if (_typesWithInnerException.Contains(exception.GetType()))
            {
                exception = exception.InnerException!;
            }

            var problemDetails = HandleException(exception, hostEnvironment, stringsLocalizedEnums)!;
            var jsonTextResponse = JsonConvert.SerializeObject(problemDetails, DefaultJsonSerializerSettings);

            httpContext.Response.StatusCode = problemDetails.Status!.Value;
            httpContext.Response.ContentType = MediaTypeNames.Application.Json;

            await httpContext.Response.WriteAsync(jsonTextResponse);
        }

        private ProblemDetailsModel HandleException(Exception exception, IHostEnvironment hostEnvironment, IStringLocalizer<StringsLocalizedEnums> stringsLocalizedEnums)
        {
            ProblemDetails problemDetails;
            var errorCode = AppErrorEnums.Unknow;
            var extensions = new Dictionary<string, object>();
            string? errorMessage = null;

            // Check type of exception.
            switch (exception)
            {
                case AppException appException:

                    var status = StatusCodes.Status500InternalServerError;
                    var type = "https://tools.ietf.org/html/rfc7231#section-6.6.1";
                    errorCode = appException.ErrorCode;

                    foreach (var item in appException.Data.Keys)
                    {
                        extensions.Add(item.ToString()!, appException.Data[item]!);
                    }

                    if (((int)appException.ErrorCode).ToString().StartsWith("404"))
                    {
                        status = StatusCodes.Status404NotFound;
                        type = "https://tools.ietf.org/html/rfc7231#section-6.5.4";
                    }
                    else if (((int)appException.ErrorCode).ToString().StartsWith("403"))
                    {
                        status = StatusCodes.Status403Forbidden;
                        type = "https://tools.ietf.org/html/rfc7231#section-6.5.3";
                    }
                    else if (((int)appException.ErrorCode).ToString().StartsWith("400"))
                    {
                        status = StatusCodes.Status400BadRequest;
                        type = "https://tools.ietf.org/html/rfc7231#section-6.5.1";
                    }
                    else if (((int)appException.ErrorCode).ToString().StartsWith("401"))
                    {
                        status = StatusCodes.Status401Unauthorized;
                        type = "https://tools.ietf.org/html/rfc7235#section-3.1";
                    }
                    else if (((int)appException.ErrorCode).ToString().StartsWith("501"))
                    {
                        status = StatusCodes.Status501NotImplemented;
                        type = "https://tools.ietf.org/html/rfc7231#section-6.6.2";
                    }

                    errorMessage = stringsLocalizedEnums.GetValue(errorCode, extensions.Select(l => l.Value).ToArray());

                    problemDetails = new ProblemDetails
                    {
                        Status = status,
                        Type = type
                    };
                    break;

                case ValidationException validationException:
                    // Get errors from exception object
                    var errors = validationException
                                    .Errors
                                    .GroupBy(l => l.PropertyName)
                                    .ToDictionary(
                                        l => l.Key,
                                        l => l.Select(ll => ll.ErrorMessage)
                                              .ToArray()
                                    );
                    errorCode = AppErrorEnums.BadRequest;
                    problemDetails = new ValidationProblemDetails(errors)
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                    };
                    break;

                case UnauthorizedAccessException unauthorizedAccessException:
                    errorCode = AppErrorEnums.Unauthorized;
                    problemDetails = new ProblemDetails
                    {
                        Status = StatusCodes.Status401Unauthorized,
                        Type = "https://tools.ietf.org/html/rfc7235#section-3.1"
                    };
                    break;

                case NotImplementedException notImplementedException:
                    errorCode = AppErrorEnums.NotImplemented;
                    problemDetails = new ProblemDetails
                    {
                        Status = StatusCodes.Status501NotImplemented,
                        Type = "https://tools.ietf.org/html/rfc7231#section-6.6.2"
                    };
                    break;

                default:
                    errorCode = AppErrorEnums.InternalServerError;
                    problemDetails = new ProblemDetails
                    {
                        Status = StatusCodes.Status500InternalServerError,
                        Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
                    };
                    break;
            }

            // Apply default values.
            problemDetails.Instance = exception.GetType().FullName;
            problemDetails.Title = errorMessage ?? exception.Message;

            // Apply only is not a production.
            if (!hostEnvironment.IsProduction())
            {
                problemDetails.Detail = exception.ToString();
            }

            var result = new ProblemDetailsModel
            {
                Instance = problemDetails.Instance,
                Detail = problemDetails.Detail,
                Status = problemDetails.Status,
                Title = problemDetails.Title,
                Type = problemDetails.Type,
                Extensions = extensions!,
                Code = errorCode
            };

            // Add parameters to title
            if (result.Extensions?.Any() ?? false)
            {
                var stringParams = string.Join(
                                        ", ",
                                        result
                                            .Extensions
                                            .Values
                                            .Select(l => l?.ToString() ?? string.Empty)
                                            .Where(l => !string.IsNullOrWhiteSpace(l))
                                    );
                result.Title = string.Join(" ", result.Title, $"({stringParams})");
            }

            return result;
        }
    }
}
