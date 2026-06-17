using Day_25_CRUD_Operations_with_Repository_Pattern.Dtos;
using Day_25_CRUD_Operations_with_Repository_Pattern.Wrapper;

namespace Day_25_CRUD_Operations_with_Repository_Pattern.Middleware
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
                _logger.LogError(ex, "Unhandle Exception: {Path}", context.Request.Path);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                var wrapperResponse = new ProductResponse<ProductResponseDto>("Something went wrong on our end while fetching the SmartContainer Data.", new List<string> { ex.Message });

                var jsonSerilize = System.Text.Json.JsonSerializer.Serialize(wrapperResponse);

                await context.Response.WriteAsync(jsonSerilize);
            }
        }
    }
}