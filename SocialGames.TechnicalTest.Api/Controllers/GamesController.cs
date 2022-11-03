using System;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SocialGames.TechnicalTest.Api.Controllers;
using SocialGames.TechnicalTest.Games.Contracts;

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
    public async Task<IActionResult> Play([FromRoute] string gameId, [FromServices] IValidator<string> _nameValidator)
    {
        var validation = _nameValidator.Validate(gameId);
        if (!validation.IsValid)
        {
            return ValidationProblem(new ValidationProblemDetails(validation.ToDictionary()));
        }
        var result = await _service.GetIndexesFactoryAsync(gameId);
        return Ok(result);
    }

    [Route("{gameId}/play/yield/seq")]
    [HttpPost]
    public async Task<IActionResult> Play2([FromRoute] string gameId)
    {
        var result = await _service.GetIndexesYieldSequentialAsync(gameId);
        return Ok(result);
    }

    [Route("{gameId}/play/yield")]
    [HttpPost]
    public async Task<IActionResult> Play3([FromRoute] string gameId)
    {
        var result = await _service.GetIndexesYieldAsync(gameId);
        return Ok(result);
    }

    [Route("{gameId}/play/seq")]
    [HttpPost]
    public async Task<IActionResult> Play4([FromRoute] string gameId)
    {
        var result = await _service.GetIndexesSequentialAsync(gameId);
        return Ok(result);
    }

    [Route("throw")]
    [HttpPost]
    public async Task<IActionResult> Throw()
    {
        throw new NotImplementedException("Hermanitos, no esta implementado aún :(");
    }
}
