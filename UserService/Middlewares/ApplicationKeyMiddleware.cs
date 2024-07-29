using System.Reflection.Metadata.Ecma335;
using Microsoft.Extensions.Primitives;

namespace UserService.Middlewares;

public class ApplicationKeyMiddleware 
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionMiddleware> _logger;

    public ApplicationKeyMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        _logger.LogInformation("ApplicationKeyMiddleware started");

        var hasKey = context.Request.Headers.TryGetValue("AppKey", out StringValues appKey);
        if (hasKey && appKey.ToString() == "MyKey")
        {
            await _next(context);
        }
        else
        {
            throw new ArgumentException("Application key is not exists");
        }
        _logger.LogInformation("ApplicationKeyMiddleware Finished");
    }
}