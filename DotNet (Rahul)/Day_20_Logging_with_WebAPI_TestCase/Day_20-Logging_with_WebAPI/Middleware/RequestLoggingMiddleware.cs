namespace Day_20_Logging_with_WebAPI.Middleware
{
    public class RequestLoggingMiddleware(RequestDelegate _next)
    {
        public async Task InvokeAsync(HttpContext context, ILogger<RequestLoggingMiddleware> _logger)
        {
            _logger.LogInformation("Request: {Method} {Path}", context.Request.Method, context.Request.Path);
            await _next(context);
            _logger.LogInformation("Response: {StatusCode}", context.Response.StatusCode);
        }
    }
}
