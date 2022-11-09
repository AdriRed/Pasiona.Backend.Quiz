using SocialGames.TechnicalTest.Resources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialGames.TechnicalTest.Games.Contracts
{
    public interface IGamesService
    {
        Task<IEnumerable<CharIndexResource>> GetIndexesAsync(string name);
    }
}
