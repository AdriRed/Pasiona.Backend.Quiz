using System.Collections.Generic;
using System.Threading.Tasks;
using SocialGames.TechnicalTest.Games.Contracts;
using SocialGames.TechnicalTest.Games.Resources;

namespace SocialGames.TechnicalTest.Games.Implementations
{
    public class GamesService : IGamesService
    {
        public async Task<IEnumerable<CharIndexResource>> GetIndexesFactoryAsync(string name)
        {
            var delay = Task.Delay(500);
            var task = Task.Factory.StartNew((state) => Comparation(state.ToString()), state: name);

            await Task.WhenAll(task, delay);

            return task.Result;
        }

        public async Task<IEnumerable<CharIndexResource>> GetIndexesYieldAsync(string name)
        {
            var delay = Task.Delay(500);
            var task = Task.Factory.StartNew((state) => ComparationYield(state.ToString()), state: name);

            await Task.WhenAll(task, delay);

            return task.Result;
        }

        public async Task<IEnumerable<CharIndexResource>> GetIndexesYieldSequentialAsync(string name)
        {
            var delay = Task.Delay(500);
            var result = ComparationYield(name);

            await delay;

            return result;
        }

        public async Task<IEnumerable<CharIndexResource>> GetIndexesSequentialAsync(string name)
        {
            var delay = Task.Delay(500);
            var result = Comparation(name);

            await delay;

            return result;
        }

        private IEnumerable<CharIndexResource> ComparationYield(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == 'o') yield break;
                yield return new CharIndexResource
                {
                    Index = i,
                    Char = str[i]
                };
            }
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