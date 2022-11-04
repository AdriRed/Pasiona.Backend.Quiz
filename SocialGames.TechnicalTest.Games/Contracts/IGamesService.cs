using System.Collections.Generic;
using System.Threading.Tasks;
using SocialGames.TechnicalTest.Games.Resources;

namespace SocialGames.TechnicalTest.Games.Contracts
{
    public interface IGamesService
    {
        Task<IEnumerable<CharIndexResource>> GetIndexesAsync(string name);
    }
}
