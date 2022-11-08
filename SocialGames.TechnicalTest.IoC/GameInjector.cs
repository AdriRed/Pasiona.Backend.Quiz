using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SocialGames.TechnicalTest.Games.Contracts;
using SocialGames.TechnicalTest.Games.Implementations;
using SocialGames.TechnicalTest.Validations.Validators;

namespace SocialGames.TechnicalTest.IoC
{
    public static class GameInjector
    {
        public static IServiceCollection RegisterGames(this IServiceCollection collection)
        {
            collection.AddSingleton<IGamesService, GamesService>();
            return collection;
        }

        public static IServiceCollection RegisterValidators(this IServiceCollection collection)
        {
            collection.AddValidatorsFromAssemblyContaining<GameNameValidator>();
            return collection;
        }
    }
}
