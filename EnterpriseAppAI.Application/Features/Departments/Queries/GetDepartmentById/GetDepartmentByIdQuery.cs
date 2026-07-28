using EnterpriseAppAI.Application.Features.Departments.DTOs;
using EnterpriseAppAI.Application.Features.Employees.DTOs;
using MediatR;

namespace EnterpriseAppAI.Application.Features.Departments.Queries.GetDepartmentById;

/// <summary>
/// Retrieves a single Department by Id as a DepartmentDto.
/// </summary>
public record GetDepartmentByIdQuery(Guid Id) : IRequest<DepartmentDto>;
