namespace EnterpriseAppAI.Application.Common.Exceptions;

/// <summary>
/// Thrown when an operation would violate a uniqueness constraint (e.g. duplicate email).
/// Caught by the API's global exception handler and translated into a 409 ProblemDetails response.
/// </summary>
public class ConflictException : Exception
{
    public ConflictException(string message) : base(message)
    {
    }
}
