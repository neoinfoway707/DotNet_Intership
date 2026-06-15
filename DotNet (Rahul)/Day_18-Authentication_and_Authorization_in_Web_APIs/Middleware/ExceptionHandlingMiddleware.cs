using Day_18_Authentication_and_Authorization_in_Web_APIs.Models;
using Day_18_Authentication_and_Authorization_in_Web_APIs.Services;
using Day_18_Authentication_and_Authorization_in_Web_APIs.Wrapper;

namespace Day_18_Authentication_and_Authorization_in_Web_APIs.Middleware
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
                
                var wrapperResponse = new CodeReviewResponse<CodeReviewSession>("Something went wrong on our end while fetching the Alert Data.", new List<string> { ex.Message });
                
                var jsonSerialize = System.Text.Json.JsonSerializer.Serialize(wrapperResponse);
                await context.Response.WriteAsync(jsonSerialize);
            }
        }
    }
}
