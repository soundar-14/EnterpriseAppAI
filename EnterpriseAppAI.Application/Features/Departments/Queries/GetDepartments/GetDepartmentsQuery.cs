using EnterpriseAppAI.Application.Features.Departments.DTOs;
using MediatR;

namespace EnterpriseAppAI.Application.Features.Departments.Queries.GetDepartments;

/// <summary>
/// Retrieves all Departments as DepartmentDto. Paging/filtering can be added later.
/// </summary>
public record GetDepartmentsQuery : IRequest<IReadOnlyList<DepartmentDto>>;
