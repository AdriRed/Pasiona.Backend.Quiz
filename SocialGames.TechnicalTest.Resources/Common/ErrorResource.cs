using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace SocialGames.TechnicalTest.Resources.Common;

public class ErrorResource
{
    public string? Message { get; set; }
    public ErrorType Type { get; set; }
    public string ErrorTypeName { get => Type.ToString(); }
    public IDictionary<string, object> Properties { get; set; } = new Dictionary<string, object>();
}

// aqui definir los tipos de error (para despues ser asociados a un status code)
public enum ErrorType
{
    Unauthorized = StatusCodes.Status401Unauthorized,
    Validation = StatusCodes.Status400BadRequest,
    NotFound = StatusCodes.Status404NotFound,
    Fatal = StatusCodes.Status500InternalServerError
}