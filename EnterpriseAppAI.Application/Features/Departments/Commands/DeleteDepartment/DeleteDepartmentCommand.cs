using MediatR;

namespace EnterpriseAppAI.Application.Features.Departments.Commands.DeleteDepartment;

/// <summary>
/// Deletes a Department by Id.
/// </summary>
public record DeleteDepartmentCommand(Guid Id) : IRequest<bool>;
