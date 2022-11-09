using SocialGames.TechnicalTest.Games.Contracts;
using SocialGames.TechnicalTest.Resources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialGames.TechnicalTest.Games.Implementations
{
    public class GamesService : IGamesService
    {
        public async Task<IEnumerable<CharIndexResource>> GetIndexesAsync(string name)
        {
            var delay = Task.Delay(500);
            var enumerable = Comparation(name);
            await delay;

            return enumerable;
        }

        private IEnumerable<CharIndexResource> ComparationYield(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == 'o')
                {
                    yield break;
                }

                yield return new CharIndexResource
                {
                    Index = i,
                    Char = str[i]
                };
            }
        }

        private IEnumerable<CharIndexResource> Comparation(string str)
        {
            var lastChar = str.Length;
            if (str.Contains('o'))
            {
                lastChar = str.IndexOf('o');
            }
            var results = new List<CharIndexResource>();
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