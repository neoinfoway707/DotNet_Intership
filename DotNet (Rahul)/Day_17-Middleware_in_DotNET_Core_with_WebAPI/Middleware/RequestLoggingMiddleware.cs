namespace Day_17_Middleware_in_DotNET_Core_with_WebAPI.Middleware
{
    public class RequestLoggingMiddleware
    {
        public readonly RequestDelegate _next;
        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine($"{context.Request.Method} {context.Request.Path}");
            await _next(context);
            Console.WriteLine($"{context.Response.StatusCode}");
        }
    }
}
