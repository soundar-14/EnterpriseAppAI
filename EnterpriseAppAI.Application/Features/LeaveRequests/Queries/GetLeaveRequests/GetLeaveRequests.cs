using EnterpriseAppAI.Application.Features.LeaveRequests.DTOs;
using MediatR;

namespace EnterpriseAppAI.Application.Features.LeaveRequests.Queries.GetLeaveRequests;

/// <summary>
/// Retrieves all leave requests.
/// </summary>
public sealed record GetLeaveRequestsQuery()
    : IRequest<IReadOnlyList<LeaveRequestDto>>;