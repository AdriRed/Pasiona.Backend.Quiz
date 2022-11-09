using System.Collections.Generic;
using System.Linq;

namespace SocialGames.TechnicalTest.Resources.Common;

public class ResultResource<T> : ResultResource<T, ErrorResource> { }

public class ResultResource<TData, TError> where TError : ErrorResource
{
    public TData? Data { get; set; }
    public bool Success { get; set; }
    public IEnumerable<TError>? Errors { get; set; }
}

public static class ResultResource
{
    public static ResultResource<T> New<T>(T? data) => new ResultResource<T>
    {
        Data = data,
        Success = true
    };
    public static ResultResource<T> Empty<T>() => New<T>(default);

    public static ResultResource<T> ToResultResource<T>(this T? data) => New(data);

    public static ResultResource<T> Error<T>(ErrorResource error) => Errors<T>(error);

    public static ResultResource<T> Errors<T>(params ErrorResource[] errors) => Empty<T>().WithErrorResources(errors.AsEnumerable());

    public static ResultResource<T> Errors<T>(IEnumerable<ErrorResource> errors) => Empty<T>().WithErrorResources(errors);

    public static ResultResource<T> WithData<T>(this ResultResource<T> result, T data) => New(data).WithErrorResources(result.Errors!);

    public static ResultResource<T> WithErrorResources<T>(this ResultResource<T> result, params ErrorResource[] errors) => result.WithErrorResources(errors.AsEnumerable());

    public static ResultResource<T> WithErrorResources<T>(this ResultResource<T> result, IEnumerable<ErrorResource>? errors)
    {
        if (errors != null)
        {
            if (result.Errors == null)
            {
                result.Errors = new List<ErrorResource>();
            }
            result.Success = false;
            result.Errors = result.Errors.Concat(errors);
        }

        return result;
    }

}
