using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.WebUtilities;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using VideoRentShop.Common;
using VideoRentShop.HttpModels.Responses;

namespace VideoRentShop.WEB.Middlewares
{
    public class GlobalExceptionHandler(IHostEnvironment env, ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
    {
        private const string UnhandledExceptionMsg = "При выполнении запроса произошло необработанное исключение.";

        private static readonly JsonSerializerOptions SerializerOptions = new(JsonSerializerDefaults.Web)
        {
            Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) },
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
            WriteIndented = true
        };

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            exception.AddErrorCode();

            var problemDetails = CreateProblemDetails(httpContext, exception);
            var json = ToJson(problemDetails);

            const string contentType = "application/problem+json";
            httpContext.Response.ContentType = contentType;
            await httpContext.Response.WriteAsync(json, cancellationToken);

            return true;
        }

        /// <summary>
        /// Создает объект ошибки, возвращаемый клиенту
        /// </summary>
        private ExceptionModel CreateProblemDetails(in HttpContext context, in Exception exception)
        {
            var errorCode = exception.GetErrorCode();
            var statusCode = context.Response.StatusCode;
            var reasonPhrase = ReasonPhrases.GetReasonPhrase(statusCode);
            if (string.IsNullOrEmpty(reasonPhrase))
            {
                reasonPhrase = UnhandledExceptionMsg;
            }

            var problemDetails = new ExceptionModel
            {
                Status = statusCode,
                Title = reasonPhrase,
                Data = new()
            };
            problemDetails.Data.Add("errorCode", errorCode);

            problemDetails.Message = exception.Message;

            if (!env.IsDevelopment())
            {
                return problemDetails;
            }

            problemDetails.Detail = exception.ToString();
            problemDetails.Data.Add("traceId", context.TraceIdentifier);
            problemDetails.Data.Add("data", exception.Data);

            return problemDetails;
        }

        /// <summary>
        /// Сериализация объекта в Json
        /// </summary>
        private string ToJson(in ExceptionModel problemDetails)
        {
            try
            {
                return JsonSerializer.Serialize(problemDetails, SerializerOptions);
            }
            catch (Exception ex)
            {
                const string msg = "Произошла ошибка при сериализации в Json.";
                logger.LogError(ex, msg);
            }

            return string.Empty;
        }
    }
}
