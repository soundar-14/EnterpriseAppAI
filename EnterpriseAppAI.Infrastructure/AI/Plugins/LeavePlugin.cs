using EnterpriseAppAI.Application.Features.LeaveRequests.Commands.ApproveLeaveRequest;
using EnterpriseAppAI.Application.Features.LeaveRequests.Commands.CancelLeaveRequest;
using EnterpriseAppAI.Application.Features.LeaveRequests.Commands.CreateLeaveRequest;
using EnterpriseAppAI.Application.Features.LeaveRequests.Commands.RejectLeaveRequest;
using EnterpriseAppAI.Application.Features.LeaveRequests.Commands.UpdateLeaveRequest;
using EnterpriseAppAI.Application.Features.LeaveRequests.DTOs;
using EnterpriseAppAI.Application.Features.LeaveRequests.Queries.GetEmployeeLeaveHistory;
using EnterpriseAppAI.Application.Features.LeaveRequests.Queries.GetLeaveRequestById;
using EnterpriseAppAI.Application.Features.LeaveRequests.Queries.GetLeaveRequests;
using EnterpriseAppAI.Infrastructure.AI.Abstractions;
using MediatR;
using Microsoft.SemanticKernel;
using System.ComponentModel;

namespace EnterpriseAppAI.Infrastructure.AI.Plugins;

public sealed class LeavePlugin : IAIPlugin
{
    private readonly IMediator _mediator;

    public LeavePlugin(IMediator mediator)
    {
        _mediator = mediator;
    }

    [KernelFunction]
    [Description("Gets a leave request by its unique identifier.")]
    public async Task<LeaveRequestDto> GetLeaveRequestByIdAsync(
        [Description("Leave Request Id")] Guid leaveRequestId,
        CancellationToken cancellationToken = default)
    {
        return await _mediator.Send(
            new GetLeaveRequestByIdQuery(leaveRequestId),
            cancellationToken);
    }

    [KernelFunction]
    [Description("Gets all leave requests.")]
    public async Task<IReadOnlyList<LeaveRequestDto>> GetLeaveRequestsAsync(
        CancellationToken cancellationToken = default)
    {
        return await _mediator.Send(
            new GetLeaveRequestsQuery(),
            cancellationToken);
    }

    [KernelFunction]
    [Description("Gets all leave requests for an employee.")]
    public async Task<IReadOnlyList<LeaveRequestDto>> GetEmployeeLeaveHistoryAsync(
        [Description("Employee Id")] Guid employeeId,
        CancellationToken cancellationToken = default)
    {
        return await _mediator.Send(
            new GetEmployeeLeaveHistoryQuery(employeeId),
            cancellationToken);
    }

    [KernelFunction]
    [Description("Creates a new leave request.")]
    public async Task<LeaveRequestDto> CreateLeaveRequestAsync(
        CreateLeaveRequestCommand command,
        CancellationToken cancellationToken = default)
    {
        return await _mediator.Send(command, cancellationToken);
    }

    [KernelFunction]
    [Description("Updates a pending leave request.")]
    public async Task<LeaveRequestDto> UpdateLeaveRequestAsync(
        UpdateLeaveRequestCommand command,
        CancellationToken cancellationToken = default)
    {
        return await _mediator.Send(command, cancellationToken);
    }

    [KernelFunction]
    [Description("Approves a pending leave request.")]
    public async Task<bool> ApproveLeaveRequestAsync(
        ApproveLeaveRequestCommand command,
        CancellationToken cancellationToken = default)
    {
        return await _mediator.Send(command, cancellationToken);
    }

    [KernelFunction]
    [Description("Rejects a pending leave request.")]
    public async Task<bool> RejectLeaveRequestAsync(
        RejectLeaveRequestCommand command,
        CancellationToken cancellationToken = default)
    {
        return await _mediator.Send(command, cancellationToken);
    }

    [KernelFunction]
    [Description("Cancels a pending leave request.")]
    public async Task<bool> CancelLeaveRequestAsync(
        CancelLeaveRequestCommand command,
        CancellationToken cancellationToken = default)
    {
        return await _mediator.Send(command, cancellationToken);
    }
}