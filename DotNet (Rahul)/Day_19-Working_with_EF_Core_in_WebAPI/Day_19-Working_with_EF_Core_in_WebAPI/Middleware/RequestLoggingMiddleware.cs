namespace Day_19_Working_with_EF_Core_in_WebAPI.Middleware
{
    public class RequestLoggingMiddleware(RequestDelegate _next)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine($"{context.Request.Method} {context.Request.Path}");
            await _next(context);
            Console.WriteLine($"{context.Response.StatusCode}");
        }
    }
}
