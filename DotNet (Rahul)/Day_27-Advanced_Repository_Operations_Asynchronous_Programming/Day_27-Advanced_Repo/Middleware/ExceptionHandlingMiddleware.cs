using Day_27_Advanced_Repository_Operations_Asynchronous_Programming.Models;
using Day_27_Advanced_Repository_Operations_Asynchronous_Programming.Wrapper;
using System.Diagnostics.Contracts;

namespace Day_27_Advanced_Repository_Operations_Asynchronous_Programming.Middleware
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

                var wrapperResponse = new MedicleSupplyResponse<MedicleSupply>("Something went wrong on our end while fetching the SmartContainer Data.", new List<string> { ex.Message });

                var jsonSerialize = System.Text.Json.JsonSerializer.Serialize(wrapperResponse);
                await context.Response.WriteAsync(jsonSerialize);
            }
        }
    }
}
