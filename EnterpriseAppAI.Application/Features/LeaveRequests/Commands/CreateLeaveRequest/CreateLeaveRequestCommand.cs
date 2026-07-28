using EnterpriseAppAI.Application.Features.LeaveRequests.DTOs;
using EnterpriseAppAI.Domain.Enums;
using MediatR;

namespace EnterpriseAppAI.Application.Features.LeaveRequests.Commands.CreateLeaveRequest;

/// <summary>
/// Creates a new leave request.
/// </summary>
public sealed record CreateLeaveRequestCommand(
    Guid EmployeeId,
    LeaveType LeaveType,
    DateOnly StartDate,
    DateOnly EndDate,
    string Reason)
    : IRequest<LeaveRequestDto>;