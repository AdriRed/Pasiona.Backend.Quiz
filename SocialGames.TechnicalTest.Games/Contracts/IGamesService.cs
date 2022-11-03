using System.Collections.Generic;
using System.Threading.Tasks;
using SocialGames.TechnicalTest.Games.Resources;

namespace SocialGames.TechnicalTest.Games.Contracts
{
    public interface IGamesService
    {
        // Task<IEnumerable<CharIndexResource>> GetIndexesAsync(string name);
        public Task<IEnumerable<CharIndexResource>> GetIndexesFactoryAsync(string name);
        public Task<IEnumerable<CharIndexResource>> GetIndexesYieldAsync(string name);
        public Task<IEnumerable<CharIndexResource>> GetIndexesYieldSequentialAsync(string name);
        public Task<IEnumerable<CharIndexResource>> GetIndexesSequentialAsync(string name);

    }
}
