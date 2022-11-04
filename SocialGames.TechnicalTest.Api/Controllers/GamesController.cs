using System;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SocialGames.TechnicalTest.Api.Controllers;
using SocialGames.TechnicalTest.Games.Contracts;
using SocialGames.TechnicalTest.Games.Resources;

namespace SocialGames.TechnicalTest.Api.Controllers;

[Route("/api/[controller]")]
public class GamesController : ControllerBase
{
    private readonly IGamesService _service;

    public GamesController(IGamesService service)
    {
        _service = service;
    }


    [Route("{gameId}/play")]
    [HttpPost]
    public async Task<IActionResult> Play([FromRoute] string gameId, [FromServices] IValidator<GameIdResource> _nameValidator)
    {
        var validation = _nameValidator.Validate(new GameIdResource { GameId = gameId });
        if (!validation.IsValid)
        {
            return ValidationProblem(new ValidationProblemDetails(validation.ToDictionary()));
        }
        var result = await _service.GetIndexesAsync(gameId);
        return Ok(result);
    }


    [Route("throw")]
    [HttpPost]
    public async Task<IActionResult> Throw()
    {
        throw new NotImplementedException("Hermanitos, no esta implementado aún :(");
    }
}
