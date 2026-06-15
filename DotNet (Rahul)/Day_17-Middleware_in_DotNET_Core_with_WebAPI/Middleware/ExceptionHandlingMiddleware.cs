using Day_17_Middleware_in_DotNET_Core_with_WebAPI.Models;
using Day_17_Middleware_in_DotNET_Core_with_WebAPI.Wrapper;

namespace Day_17_Middleware_in_DotNET_Core_with_WebAPI.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        public readonly RequestDelegate _next;
        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                
                var wrapperRespone = new AlertResponse<Alert>("Something went wrong on our end while fetching the Alert Data.", new List<string> { ex.Message });
                var jsonSerialize = System.Text.Json.JsonSerializer.Serialize(wrapperRespone);

                await context.Response.WriteAsync(jsonSerialize);
            }
        }
    }
}
