using ProductManagement.Application.Common.Dtos;
using ProductManagement.WebApi.Wrapper;

namespace ProductManagement.WebApi.Middleware
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
                _logger.LogError(ex, "Unhandled Exception at : {Path}", context.Request.Path); 
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                
                var wrapperResponse = new ProductResponse<ProductResponseDto>("Something went wrong on our end while fetching the Product Data.", new List<string> { ex.Message });
                
                var jsonSerilize = System.Text.Json.JsonSerializer.Serialize(wrapperResponse);

                await context.Response.WriteAsync(jsonSerilize);
            }
        }
    }
}
