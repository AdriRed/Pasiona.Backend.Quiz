using FluentValidation;

namespace SocialGames.TechnicalTest.Api.Validators;
public class GameNameValidator : AbstractValidator<string>
{
    public GameNameValidator()
    {
        RuleFor(x => x).Equal("eltesorodejava");
    }
}
