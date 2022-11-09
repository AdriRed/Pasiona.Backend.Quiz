using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using SocialGames.TechnicalTest.Resources.Common;
using SocialGames.TechnicalTest.Resources.Common.Errors;
using System.Diagnostics;
using System.Threading.Tasks;

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
            var logger = factory.CreateLogger(ex.Source);
            logger.LogError(ex.Demystify(), "Catched error in GlobalExceptionMiddleware");

            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await context.Response.WriteAsJsonAsync(ResultResource.Empty<object>().WithFatalError(ex));
        }
    }
}