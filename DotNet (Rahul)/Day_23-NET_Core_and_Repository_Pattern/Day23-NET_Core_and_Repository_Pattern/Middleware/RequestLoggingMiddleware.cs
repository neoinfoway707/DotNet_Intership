namespace Day23_NET_Core_and_Repository_Pattern.Middleware
{
    public class RequestLoggingMiddleware(RequestDelegate _next, ILogger<RequestLoggingMiddleware> _logger)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            _logger.LogInformation("Request: {Method} {Path}", context.Request.Method, context.Request.Path);
            await _next(context);
            _logger.LogInformation("Response: {StatusCode}", context.Response.StatusCode);
        }
    }
}
