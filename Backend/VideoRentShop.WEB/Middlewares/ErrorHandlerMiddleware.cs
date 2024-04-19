using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Text.Json;
using System.Text.Json.Serialization;
using VideoRentShop.Common;

namespace VideoRentShop.WEB.Middlewares
{
    public class ErrorHandlerMiddleware : IMiddleware
    {
        private const string UnhandledExceptionMsg = "При выполнении запроса произошло необработанное исключение.";

        private static readonly JsonSerializerOptions SerializerOptions = new(JsonSerializerDefaults.Web)
        {
            Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
        };

        public ErrorHandlerMiddleware()
        {
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                next(context);
            }
            catch (Exception ex) when (context.RequestAborted.IsCancellationRequested)
            {
                const string message = "Пользователь отменил запрос.";

                context.Response.Clear();
                context.Response.StatusCode = 499; //Client Closed Request
            }
            catch(Exception ex)
            {
                ex.AddErrorCode();

                const string contentType = "application/problem+json";
                context.Response.Clear();
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = contentType;

                var problemDetails = CreateProblemDetails(context, ex);
                var json = ToJson(problemDetails);
                await context.Response.WriteAsync(json);
            }
        }

        private ProblemDetails CreateProblemDetails(in HttpContext context, in Exception exception)
        {
            var errorCode = exception.GetErrorCode();
            var statusCode = context.Response.StatusCode;
            var reasonPhrase = ReasonPhrases.GetReasonPhrase(statusCode);
            if (string.IsNullOrEmpty(reasonPhrase))
            {
                reasonPhrase = UnhandledExceptionMsg;
            }

            var problemDetails = new ProblemDetails
            {
                Status = statusCode,
                Title = reasonPhrase,
                Extensions =
            {
                [nameof(errorCode)] = errorCode
            }
            };

            /*if (!_env.IsDevelopment())
            {
                return problemDetails;
            }*/

            problemDetails.Detail = exception.ToString();
            problemDetails.Extensions["traceId"] = context.TraceIdentifier;
            problemDetails.Extensions["data"] = exception.Data;

            return problemDetails;
        }

        private string ToJson(in ProblemDetails problemDetails)
        {
            try
            {
                return JsonSerializer.Serialize(problemDetails, SerializerOptions);
            }
            catch (Exception ex)
            {
                const string message = "Произошла ошибка при сериализации Json.";
            }

            return string.Empty;
        }
    }
}
