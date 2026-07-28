using MediatR;

namespace EnterpriseAppAI.Application.Features.LeaveRequests.Commands.RejectLeaveRequest;

/// <summary>
/// Rejects a pending leave request.
/// </summary>
public sealed record RejectLeaveRequestCommand(
    Guid LeaveRequestId,
    Guid RejectedBy,
    string ManagerComments)
    : IRequest<bool>;