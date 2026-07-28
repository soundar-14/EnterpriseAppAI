using MediatR;

namespace EnterpriseAppAI.Application.Features.Departments.Commands.CreateDepartment;

/// <summary>
/// Creates a new Department. No Id - the database generates it.
/// </summary>
public record CreateDepartmentCommand(
    string Name,
    string Code) : IRequest<Guid>;
