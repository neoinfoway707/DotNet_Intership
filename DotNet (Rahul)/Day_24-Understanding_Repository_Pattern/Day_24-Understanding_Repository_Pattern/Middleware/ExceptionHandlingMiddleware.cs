using Day_24_Understanding_Repository_Pattern.Models;
using Day_24_Understanding_Repository_Pattern.Wrapper;

namespace Day_24_Understanding_Repository_Pattern.Middleware
{
    public class ExceptionHandlingMiddleware(RequestDelegate _next, ILogger<ExceptionHandlingMiddleware> _logger)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandle Exception : {Path}", context.Request.Path);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                var wrapperResponse = new TrackResponse<Track>("Something went wrong on our end while fetching the SmartContainer Data.", new List<string> { ex.Message });

                string jsonSerilize = System.Text.Json.JsonSerializer.Serialize(wrapperResponse);
                await context.Response.WriteAsync(jsonSerilize);
            }
        }
    }
}
