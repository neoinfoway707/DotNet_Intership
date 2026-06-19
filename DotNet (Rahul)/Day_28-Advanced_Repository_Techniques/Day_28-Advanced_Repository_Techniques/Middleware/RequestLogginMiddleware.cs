namespace Day_28_Advanced_Repository_Techniques.Middleware
{
    public class RequestLogginMiddleware(RequestDelegate _next, ILogger<RequestLogginMiddleware> _logger)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            _logger.LogInformation("Request: {Method} {Path} ", context.Request.Method, context.Request.Path);
            await _next(context);
            _logger.LogInformation("Response: {StatusCode} ", context.Response.StatusCode);
        }
    }
}
