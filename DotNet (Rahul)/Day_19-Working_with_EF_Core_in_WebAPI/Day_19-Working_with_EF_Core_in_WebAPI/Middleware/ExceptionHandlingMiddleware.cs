
using Day_19_Working_with_EF_Core_in_WebAPI.Models;
using Day_19_Working_with_EF_Core_in_WebAPI.Wrapper;

namespace Day_19_Working_with_EF_Core_in_WebAPI.Middleware
{
    public class ExceptionHandlingMiddleware(RequestDelegate _next)
    {
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
                
                var wrapperResponse = new SmartContainerResponse<SmartContainer>("Something went wrong on our end while fetching the Alert Data.", new List<string> { ex.Message });
                
                var jsonSerialize = System.Text.Json.JsonSerializer.Serialize(wrapperResponse);
                await context.Response.WriteAsync(jsonSerialize);
            }
        }
    }
}
