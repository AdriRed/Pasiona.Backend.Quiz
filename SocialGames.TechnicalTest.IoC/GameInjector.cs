using Microsoft.Extensions.DependencyInjection;

namespace SocialGames.TechnicalTest.IoC
{
    public static class GameInjector
    {
        public static IServiceCollection RegisterGames(this IServiceCollection collection) {
            return collection;
        }
    }
}
