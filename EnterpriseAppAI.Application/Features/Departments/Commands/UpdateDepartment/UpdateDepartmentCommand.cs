using MediatR;

namespace EnterpriseAppAI.Application.Features.Departments.Commands.UpdateDepartment;

/// <summary>
/// Updates an existing Department's editable fields.
/// </summary>
public record UpdateDepartmentCommand(
    Guid Id,
    string Name,
    string Code,
    bool IsActive) : IRequest<bool>;
