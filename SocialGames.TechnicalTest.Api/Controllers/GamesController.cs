using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SocialGames.TechnicalTest.Api.Controllers;
using SocialGames.TechnicalTest.Api.Controllers.Base;
using SocialGames.TechnicalTest.Games.Contracts;
using SocialGames.TechnicalTest.Resources;
using SocialGames.TechnicalTest.Resources.Common;
using SocialGames.TechnicalTest.Validations.Errors;

namespace SocialGames.TechnicalTest.Api.Controllers;

[Route("/api/[controller]")]
public class GamesController : ApiController
{
    private readonly IGamesService _gameService;

    public GamesController(IGamesService service)
    {
        _gameService = service;
    }


    [Route("{gameId}/play")]
    [HttpPost]
    public async Task<IActionResult> Play([FromRoute] string gameId, [FromServices] IValidator<GameIdResource> _nameValidator)
    {
        var validation = _nameValidator.Validate(new GameIdResource { GameId = gameId });
        if (!validation.IsValid)
        {
            return Response(ResultResource.Empty<IEnumerable<CharIndexResource>>().WithValidationErrors(validation));
        }
        var result = await _gameService.GetIndexesAsync(gameId);
        return Response(result.ToResultResource());
    }


    [Route("throw")]
    [HttpPost]
    public IActionResult Throw()
    {
        throw new NotImplementedException("Hermanitos, no esta implementado aún :(");
    }
}
