using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Peach_ActiviGo.Api.MiddleWare
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;
        public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception occurred.");
                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            var response = new ErrorResponse();

            switch (exception)
            {
                // System.ComponentModel.DataAnnotations Validation
                case System.ComponentModel.DataAnnotations.ValidationException dataAnnotationsValidationEx:
                    response.Message = "Validation failed";
                    response.Details.Add(dataAnnotationsValidationEx.Message);
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;

                // FluentValidation
                case FluentValidation.ValidationException fluentValidationEx:
                    response.Message = "Validation failed";
                    var errors = fluentValidationEx.Errors?.Select(e => e.ErrorMessage).Distinct();
                    if (errors != null)
                        response.Details.AddRange(errors);
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;

                case ArgumentNullException argNullEx:
                    response.Message = "Missing required argument";
                    response.Details.Add(argNullEx.Message);
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;

                case ArgumentException argEx:
                    response.Message = "Invalid argument";
                    response.Details.Add(argEx.Message);
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;

                case JsonException jsonEx:
                    response.Message = "Malformed JSON in request body";
                    response.Details.Add(jsonEx.Message);
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;

                case FormatException formatEx:
                    response.Message = "Invalid format";
                    response.Details.Add(formatEx.Message);
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;

                case UnauthorizedAccessException unAuthEx:
                    response.Message = "Unauthorized access";
                    response.Details.Add(unAuthEx.Message);
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    break;

                // Token validation problems (JWT)
                case SecurityTokenExpiredException tokenExpiredEx:
                    response.Message = "Token expired";
                    response.Details.Add(tokenExpiredEx.Message);
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    break;

                case SecurityTokenException tokenEx:
                    response.Message = "Invalid token";
                    response.Details.Add(tokenEx.Message);
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    break;

                case KeyNotFoundException keyNotFoundEx:
                    response.Message = "Resource not found";
                    response.Details.Add(keyNotFoundEx.Message);
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;

                case DbUpdateConcurrencyException dbConcurrencyEx:
                    response.Message = "Database concurrency conflict";
                    response.Details.Add(dbConcurrencyEx.Message);
                    context.Response.StatusCode = (int)HttpStatusCode.Conflict;
                    break;

                case DbUpdateException dbEx:
                    response.Message = "Database update failed";
                    response.Details.Add(dbEx.InnerException?.Message ?? dbEx.Message);
                    context.Response.StatusCode = (int)HttpStatusCode.Conflict;
                    break;

                case Exception sqlEx when sqlEx.GetType().Name.Equals("SqlException", StringComparison.OrdinalIgnoreCase):
                    response.Message = "Database error";
                    response.Details.Add(sqlEx.Message);
                    context.Response.StatusCode = (int)HttpStatusCode.ServiceUnavailable;
                    break;

                case HttpRequestException httpReqEx:
                    response.Message = "External service error";
                    response.Details.Add(httpReqEx.Message);
                    context.Response.StatusCode = (int)HttpStatusCode.ServiceUnavailable;
                    break;

                case OperationCanceledException opCanceledEx:
                    response.Message = "Operation canceled or timed out";
                    response.Details.Add(opCanceledEx.Message);
                    context.Response.StatusCode = (int)HttpStatusCode.RequestTimeout;
                    break;


                case InvalidOperationException invalidOperationEx:
                    response.Message = "Invalid operation";
                    response.Details.Add(invalidOperationEx.Message);
                    context.Response.StatusCode = (int)HttpStatusCode.Conflict;
                    break;

                default:
                    response.Message = "An unexpected error occurred.";
                    response.Details.Add(exception.Message);
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            var jsonResponse = JsonSerializer.Serialize(response, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            await context.Response.WriteAsync(jsonResponse);
        }
    }

    public class ErrorResponse
    {
        public string Message { get; set; } = string.Empty;
        public List<string> Details { get; set; } = new();
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}
