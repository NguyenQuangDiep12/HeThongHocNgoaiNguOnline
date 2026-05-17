using OELS.Service.Exceptions;
using System.Net;
using System.Text.Json;

namespace OELS.Api.Middlewares
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        private readonly IHostEnvironment _env;

        public GlobalExceptionMiddleware(
            RequestDelegate next, 
            ILogger<GlobalExceptionMiddleware> logger, 
            IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context); // Call the next middleware
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An unhandled exception occurred: {ex.Message}");
                await HandleExceptionAsync(context, ex);
            }
        }
        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = ex switch
            {
                UnauthorizedException => (int)HttpStatusCode.Unauthorized,
                DuplicateEmailException => (int)HttpStatusCode.Conflict,
                _=> (int)HttpStatusCode.InternalServerError
            };

            var errorDetails = new
            {
                StatusCode = context.Response.StatusCode,
                Message = "An unexpected error occurred.",
                Detail = _env.IsDevelopment() ? ex.StackTrace : null
            };
            var errorJson = JsonSerializer.Serialize(errorDetails);
            return context.Response.WriteAsync(errorJson);
        }
    }
}
