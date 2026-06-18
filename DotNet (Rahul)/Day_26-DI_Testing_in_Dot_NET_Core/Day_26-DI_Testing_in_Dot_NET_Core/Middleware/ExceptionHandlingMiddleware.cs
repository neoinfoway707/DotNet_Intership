using Day_26_DI_Testing_in_Dot_NET_Core.Models;
using Day_26_DI_Testing_in_Dot_NET_Core.Wrapper;

namespace Day_26_DI_Testing_in_Dot_NET_Core.Middleware
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
                _logger.LogError(ex, "Unhandle Exception : {Path}", context.Request.Path);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                var wrapperResponse = new VendorResponse<Vendor>("Something went wrong on our end while fetching the SmartContainer Data.", new List<string> { ex.Message });

                string jsonSerilize = System.Text.Json.JsonSerializer.Serialize(wrapperResponse);
                await context.Response.WriteAsync(jsonSerilize);
            }
        }
    }
}
