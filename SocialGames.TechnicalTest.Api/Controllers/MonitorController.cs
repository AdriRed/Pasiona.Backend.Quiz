using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SocialGames.TechnicalTest.Api.Controllers.Base;

namespace SocialGames.TechnicalTest.Api.Controllers;

public class MonitorController : ApiControllerBase<MonitorController>
{
    public MonitorController(ILogger<MonitorController> logger) : base(logger)
    {
    }

    [HttpGet("/")]
    public IActionResult Heartbeat()
    {
        return Ok();
    }

    [HttpGet]
    [Route("ping")]
    public IActionResult Ping()
    {
        return Ok("pong");
    }
}
