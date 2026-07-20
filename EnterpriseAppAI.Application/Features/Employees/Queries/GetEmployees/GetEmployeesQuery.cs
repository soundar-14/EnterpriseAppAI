using EnterpriseAppAI.Application.Features.Employees.DTOs;
using MediatR;

namespace EnterpriseAppAI.Application.Features.Employees.Queries.GetEmployees;

/// <summary>
/// Retrieves all Employees as EmployeeDto. Paging/filtering can be added later.
/// </summary>
public record GetEmployeesQuery : IRequest<IReadOnlyList<EmployeeDto>>;
