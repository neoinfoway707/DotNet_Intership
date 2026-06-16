
using Day_20_Logging_with_WebAPI.Models;
using Day_20_Logging_with_WebAPI.Wrapper;

namespace Day_20_Logging_with_WebAPI.Middleware
{
    public class ExceptionHandlingMiddleware(RequestDelegate _next,ILogger<ExceptionHandlingMiddleware> _logger)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception: {Path}", context.Request.Path);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                
                var wrapperResponse = new SmartContainerResponse<SmartContainer>("Something went wrong on our end while fetching the Alert Data.", new List<string> { ex.Message });
                
                var jsonSerialize = System.Text.Json.JsonSerializer.Serialize(wrapperResponse);
                await context.Response.WriteAsync(jsonSerialize);
            }
        }
    }
}
