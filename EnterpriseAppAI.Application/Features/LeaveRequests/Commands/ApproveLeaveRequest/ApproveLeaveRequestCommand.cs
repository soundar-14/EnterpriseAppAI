using MediatR;

namespace EnterpriseAppAI.Application.Features.LeaveRequests.Commands.ApproveLeaveRequest;

/// <summary>
/// Approves a pending leave request.
/// </summary>
public sealed record ApproveLeaveRequestCommand(
    Guid LeaveRequestId,
    Guid ApprovedBy,
    string? ManagerComments)
    : IRequest<bool>;