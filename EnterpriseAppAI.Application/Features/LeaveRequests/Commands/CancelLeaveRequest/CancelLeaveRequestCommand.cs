using MediatR;

namespace EnterpriseAppAI.Application.Features.LeaveRequests.Commands.CancelLeaveRequest;

/// <summary>
/// Cancels a pending leave request.
/// </summary>
public sealed record CancelLeaveRequestCommand(
    Guid LeaveRequestId,
    Guid EmployeeId)
    : IRequest<bool>;