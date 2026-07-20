using EnterpriseAppAI.Application.Features.Employees.DTOs;
using MediatR;

namespace EnterpriseAppAI.Application.Features.Employees.Queries.GetEmployeeById;

/// <summary>
/// Retrieves a single Employee by Id as an EmployeeDto.
/// </summary>
public record GetEmployeeByIdQuery(Guid Id) : IRequest<EmployeeDto?>;
