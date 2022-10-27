using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SocialGames.TechnicalTest.Api.Controllers
{
    [ApiController]
    public class GamesControllers : ControllerBase
    {
        [Route("api/games/{gameId}/play")]
        [HttpPost]
        public async Task<IActionResult> Play(string gameId)
        {
            return Ok(gameId);
        }
    }
}
