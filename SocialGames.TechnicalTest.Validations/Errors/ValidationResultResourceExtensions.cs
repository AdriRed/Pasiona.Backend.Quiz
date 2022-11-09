using FluentValidation.Results;
using SocialGames.TechnicalTest.Resources.Common;
using System.Linq;

namespace SocialGames.TechnicalTest.Validations.Errors;

public static class ValidationErrorResourceExtensions
{
    public static ResultResource<T> WithValidationErrors<T>(this ResultResource<T> resource, ValidationResult results)
    {
        var errors = results.Errors.GroupBy(x => x.PropertyName).Select(x =>
            new ValidationErrorResource()
            {
                Message = $"Invalid field value",
                Field = x.Key,
                Reasons = x.Select(x => x.ErrorMessage).ToArray()
            }
        );

        return resource.WithErrorResources(errors);
    }
}
