using EnterpriseAppAI.Application.Features.LeaveRequests.DTOs;
using MediatR;

namespace EnterpriseAppAI.Application.Features.LeaveRequests.Queries.GetEmployeeLeaveHistory;

/// <summary>
/// Retrieves all leave requests for a specific employee.
/// </summary>
public sealed record GetEmployeeLeaveHistoryQuery(Guid EmployeeId)
    : IRequest<IReadOnlyList<LeaveRequestDto>>;