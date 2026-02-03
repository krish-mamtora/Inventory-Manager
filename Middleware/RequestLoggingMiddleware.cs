namespace SimpleStore.Middleware;

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;

    public RequestLoggingMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task Invoke(HttpContext context)
    {
        Console.WriteLine($"{DateTime.Now}");
        await _next(context);
    }
} 