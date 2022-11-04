using FluentValidation;
using SocialGames.TechnicalTest.Games.Resources;

namespace SocialGames.TechnicalTest.Api.Validators;
public class GameNameValidator : AbstractValidator<GameIdResource>
{
    public GameNameValidator()
    {
        RuleFor(x => x.GameId).Equal("eltesorodejava");
    }
}
