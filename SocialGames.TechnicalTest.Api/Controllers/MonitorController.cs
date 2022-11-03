using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SocialGames.TechnicalTest.Api.Controllers;

public class MonitorController : ControllerBase
{

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
