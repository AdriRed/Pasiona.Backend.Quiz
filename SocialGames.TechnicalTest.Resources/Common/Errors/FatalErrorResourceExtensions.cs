using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialGames.TechnicalTest.Resources.Common.Errors;

public static class FatalErrorResourceExtensions
{
    public static ResultResource<T> WithFatalError<T>(this ResultResource<T> result, Exception ex)
    {
        var fatalError = new FatalErrorResource
        {
            Message = ex.Message,
            Exception = ex.ToString()
        };

        return result.WithErrorResources(fatalError);
    }
}
