using MediatR;

namespace EnterpriseAppAI.Application.Features.Employees.Commands.CreateEmployee;

/// <summary>
/// Creates a new Employee. No Id - the database generates it.
/// </summary>
public record CreateEmployeeCommand(
    string EmployeeNumber,
    string FirstName,
    string LastName,
    string Email,
    Guid DepartmentId) : IRequest<Guid>;
