using Day_22_Implement_Login_functionality_with_WebAPI.Wrapper;
using Day_22_Implement_Login_functionality_with_WebAPI.Models;

namespace Day_22_Implement_Login_functionality_with_WebAPI.Middleware
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

                var wrapperResponse = new UserResponse<User>("Something went wrong on our end while fetching the SmartContainer Data.", new List<string> { ex.Message });

                string jsonSerilize = System.Text.Json.JsonSerializer.Serialize(wrapperResponse);
                await context.Response.WriteAsync(jsonSerilize);
            }
        }
    }
}
