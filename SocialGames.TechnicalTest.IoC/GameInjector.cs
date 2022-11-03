using Microsoft.Extensions.DependencyInjection;
using SocialGames.TechnicalTest.Games.Contracts;
using SocialGames.TechnicalTest.Games.Implementations;

namespace SocialGames.TechnicalTest.IoC
{
    public static class GameInjector
    {
        public static IServiceCollection RegisterGames(this IServiceCollection collection) 
        {
            collection.AddSingleton<IGamesService, GamesService>();
            return collection;
        }
    }
}
