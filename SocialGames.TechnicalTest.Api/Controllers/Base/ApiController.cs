using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialGames.TechnicalTest.Games.Resources.Common;
using SocialGames.TechnicalTest.Resources.Common;

namespace SocialGames.TechnicalTest.Api.Controllers.Base;

public class ApiController : ControllerBase
{
    public new ObjectResult Response<T>(T obj) => Response(obj.ToResultResource());

    public new ObjectResult Response<T>(ResultResource<T> result)
    {
        ObjectResult response;
        if (result.Success)
        {
            response = base.Ok(result);
        }
        else
        {
            var errorTypes = result.Errors.Select(x => x.Type).Distinct();
            if (errorTypes.Count() > 1) // muchos errores con diferente tipo
            {
                response = base.BadRequest(result);
            }
            else
            {
                var errorType = errorTypes.First();

                // si aquí se quiere definir un codigo de error diferente al status code se puede implementar con un diccionario
                response = StatusCode((int)errorType, result);

            }
        }

        return response;
    }
}