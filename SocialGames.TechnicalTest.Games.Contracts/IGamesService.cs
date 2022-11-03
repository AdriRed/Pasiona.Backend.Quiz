using System.Collections.Generic;
using SocialGames.TechnicalTest.Resources;

namespace SocialGames.TechnicalTest.Games.Contracts
{
    public interface IGamesService
    {
        Task<IEnumerable<CharIndexResource>> GetIndexesAsync(string name);
    }
}
