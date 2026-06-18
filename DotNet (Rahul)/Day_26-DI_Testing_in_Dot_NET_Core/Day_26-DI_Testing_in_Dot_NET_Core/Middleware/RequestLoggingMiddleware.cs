namespace Day_26_DI_Testing_in_Dot_NET_Core.Middleware
{
    public class RequestLoggingMiddleware(RequestDelegate _next,ILogger<RequestLoggingMiddleware> _logger)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            _logger.LogInformation("Request: {Method} {Path}", context.Request.Method, context.Request.Path);
            await _next(context);
            _logger.LogInformation("Response: {StatusCode}", context.Response.StatusCode);
        }
    }
}
