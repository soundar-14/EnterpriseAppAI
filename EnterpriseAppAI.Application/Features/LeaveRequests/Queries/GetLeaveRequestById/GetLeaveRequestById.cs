using EnterpriseAppAI.Application.Features.LeaveRequests.DTOs;
using MediatR;

namespace EnterpriseAppAI.Application.Features.LeaveRequests.Queries.GetLeaveRequestById;

/// <summary>
/// Gets one Leave Request.
/// </summary>
public sealed record GetLeaveRequestByIdQuery(Guid Id)
    : IRequest<LeaveRequestDto>;