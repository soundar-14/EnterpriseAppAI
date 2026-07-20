using MediatR;

namespace EnterpriseAppAI.Application.Features.Employees.Commands.DeleteEmployee;

/// <summary>
/// Deletes an Employee by Id.
/// </summary>
public record DeleteEmployeeCommand(Guid Id) : IRequest<bool>;
