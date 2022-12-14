using FluentValidation;
using SocialGames.TechnicalTest.Resources;

namespace SocialGames.TechnicalTest.Validations.Validators;
public class GameNameValidator : AbstractValidator<GameIdResource>
{
    public GameNameValidator()
    {
        RuleFor(x => x.GameId).NotNull().Equal("eltesorodejava");
    }
}
