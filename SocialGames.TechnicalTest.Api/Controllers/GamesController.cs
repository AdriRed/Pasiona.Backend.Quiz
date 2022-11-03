using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SocialGames.TechnicalTest.Api.Controllers.Base;

namespace SocialGames.TechnicalTest.Api.Controllers;

[Route("/api/[controller]")]
public class GamesController : ApiControllerBase<GamesController>
{
    public GamesController(ILogger<GamesController> logger) : base(logger)
    {
    }

    [Route("{gameId}/play")]
    [HttpPost]
    public async Task<IActionResult> Play([FromRoute] string gameId)
    {
        return Ok(gameId);
    }

    [Route("throw")]
    [HttpPost]
    public async Task<IActionResult> Throw()
    {
        throw new NotImplementedException("Hermanitos, no esta implementado aún :(");
    }
}
