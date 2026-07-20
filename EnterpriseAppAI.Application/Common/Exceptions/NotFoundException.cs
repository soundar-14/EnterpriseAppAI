namespace EnterpriseAppAI.Application.Common.Exceptions;

/// <summary>
/// Thrown by handlers when a requested entity does not exist. Caught by the API's
/// global exception handler and translated into a 404 ProblemDetails response.
/// </summary>
public class NotFoundException : Exception
{
    public NotFoundException(string name, object key)
        : base($"Entity \"{name}\" ({key}) was not found.")
    {
    }
}
