namespace SimpleStore.Middleware;

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

public class RequestLoggerMiddleware
{
    private readonly RequestDelegate _next;
    public RequestLoggerMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task InvokeAsync(HttpContext context)
    {
        Console.WriteLine($"Request received at {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
        await _next(context); 
    }
}
