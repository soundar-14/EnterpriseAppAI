using EnterpriseAppAI.Application.Features.LeaveRequests.DTOs;
using EnterpriseAppAI.Domain.Enums;
using MediatR;

namespace EnterpriseAppAI.Application.Features.LeaveRequests.Commands.UpdateLeaveRequest;

/// <summary>
/// Updates an existing pending leave request.
/// </summary>
public sealed record UpdateLeaveRequestCommand(
    Guid LeaveRequestId,
    LeaveType LeaveType,
    DateOnly StartDate,
    DateOnly EndDate,
    string Reason)
    : IRequest<LeaveRequestDto>;