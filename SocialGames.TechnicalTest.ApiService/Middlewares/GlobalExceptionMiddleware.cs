using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace SocialGames.TechnicalTest.ApiService.Middlewares;

// Tambien podría haber utilizado un exception filter
public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public GlobalExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, ILoggerFactory factory)
    {
        try
        {
            await _next(context);
        }
        catch (System.Exception ex)
        {
            var logger = factory.CreateLogger($"{ex.TargetSite.Module.Name}@{ex.TargetSite.Name}");

            logger.LogError(ex, "Catched error in GlobalExceptionMiddleware");
        }
    }
}