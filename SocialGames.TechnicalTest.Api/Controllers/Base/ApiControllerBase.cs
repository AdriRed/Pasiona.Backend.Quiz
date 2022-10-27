using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SocialGames.TechnicalTest.Api.Controllers.Base;

[ApiController]
public class ApiControllerBase<T> : ControllerBase
{
    protected readonly ILogger<T> Logger;

    public ApiControllerBase(ILogger<T> logger)
    {
        Logger = logger;
    }
}

