using MediatR;

namespace EnterpriseAppAI.Application.Features.Employees.Commands.UpdateEmployee;

/// <summary>
/// Updates an existing Employee's editable fields.
/// </summary>
public record UpdateEmployeeCommand(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    Guid DepartmentId,
    bool IsActive) : IRequest<bool>;
