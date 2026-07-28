namespace EnterpriseAppAI.Application.Common.Exceptions;

/// <summary>
/// Represents a business rule violation.
/// </summary>
public sealed class BusinessRuleException : Exception
{
    public BusinessRuleException(string message)
        : base(message)
    {
    }
}