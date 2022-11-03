using System.Collections.Generic;
using System.Threading.Tasks;
using SocialGames.TechnicalTest.Games.Contracts;
using SocialGames.TechnicalTest.Resources;

namespace SocialGames.TechnicalTest.Games.Implementations
{
    public class GamesService : IGamesService
    {
        public async Task<IEnumerable<CharIndexResource>> GetIndexesAsync(string name)
        {
            var task = Task.Factory.StartNew((state) => Comparation(state.ToString()), state:name);
            var delay = Task.Delay(500);

            await Task.WhenAll(task, delay);

            return task.Result;
        }

        private IEnumerable<CharIndexResource> Comparation(string str)
        {
            int lastChar = str.Length;
            if (str.Contains('o'))
            {
                lastChar = str.IndexOf('o');
            }
            IList<CharIndexResource> results = new List<CharIndexResource>();
            for (int i = 0; i < lastChar; i++)
            {
                results.Add(new CharIndexResource
                {
                    Index = i,
                    Char = str[i]
                });
            }
            return results;
        }
    }
}