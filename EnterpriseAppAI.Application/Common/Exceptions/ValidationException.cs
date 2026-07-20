using FluentValidation.Results;

namespace EnterpriseAppAI.Application.Common.Exceptions;

/// <summary>
/// Thrown by <see cref="Behaviors.ValidationBehavior{TRequest,TResponse}"/> when one or more
/// FluentValidation validators fail. Caught by the API's global exception handler and
/// translated into a 400 ProblemDetails response with per-field error details.
/// </summary>
public class ValidationException : Exception
{
    public ValidationException()
        : base("One or more validation failures have occurred.")
    {
        Errors = new Dictionary<string, string[]>();
    }

    public ValidationException(IEnumerable<ValidationFailure> failures)
        : this()
    {
        Errors = failures
            .GroupBy(f => f.PropertyName, f => f.ErrorMessage)
            .ToDictionary(g => g.Key, g => g.ToArray());
    }

    public IDictionary<string, string[]> Errors { get; }
}
