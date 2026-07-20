namespace EnterpriseAppAI.Application.Common.Exceptions;

/// <summary>
/// Thrown when credentials are invalid. Caught by the API's global exception handler
/// and translated into a 401 ProblemDetails response.
/// </summary>
public class UnauthorizedException : Exception
{
    public UnauthorizedException(string message) : base(message)
    {
    }
}
