namespace Day_18_Authentication_and_Authorization_in_Web_APIs.Middleware
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
