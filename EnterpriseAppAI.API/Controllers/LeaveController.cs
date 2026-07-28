using EnterpriseAppAI.Application.Features.LeaveRequests.Commands.ApproveLeaveRequest;
using EnterpriseAppAI.Application.Features.LeaveRequests.Commands.CancelLeaveRequest;
using EnterpriseAppAI.Application.Features.LeaveRequests.Commands.CreateLeaveRequest;
using EnterpriseAppAI.Application.Features.LeaveRequests.Commands.RejectLeaveRequest;
using EnterpriseAppAI.Application.Features.LeaveRequests.Commands.UpdateLeaveRequest;
using EnterpriseAppAI.Application.Features.LeaveRequests.Queries.GetEmployeeLeaveHistory;
using EnterpriseAppAI.Application.Features.LeaveRequests.Queries.GetLeaveRequestById;
using EnterpriseAppAI.Application.Features.LeaveRequests.Queries.GetLeaveRequests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EnterpriseAppAI.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LeaveController : ControllerBase
{
    private readonly IMediator _mediator;

    public LeaveController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(
            new GetLeaveRequestsQuery(),
            cancellationToken);

        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(
        Guid id,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(
            new GetLeaveRequestByIdQuery(id),
            cancellationToken);

        return Ok(result);
    }

    [HttpGet("employee/{employeeId:guid}")]
    public async Task<IActionResult> GetEmployeeHistory(
        Guid employeeId,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(
            new GetEmployeeLeaveHistoryQuery(employeeId),
            cancellationToken);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateLeaveRequestCommand command,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(
            command,
            cancellationToken);

        return CreatedAtAction(
            nameof(GetById),
            new { id = result.Id },
            result);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(
        Guid id,
        UpdateLeaveRequestCommand command,
        CancellationToken cancellationToken)
    {
        if (id != command.LeaveRequestId)
        {
            return BadRequest("Route id does not match request id.");
        }

        var result = await _mediator.Send(
            command,
            cancellationToken);

        return Ok(result);
    }

    [HttpPost("{id:guid}/approve")]
    public async Task<IActionResult> Approve(
        Guid id,
        ApproveLeaveRequestCommand command,
        CancellationToken cancellationToken)
    {
        if (id != command.LeaveRequestId)
        {
            return BadRequest("Route id does not match request id.");
        }

        await _mediator.Send(command, cancellationToken);

        return NoContent();
    }

    [HttpPost("{id:guid}/reject")]
    public async Task<IActionResult> Reject(
        Guid id,
        RejectLeaveRequestCommand command,
        CancellationToken cancellationToken)
    {
        if (id != command.LeaveRequestId)
        {
            return BadRequest("Route id does not match request id.");
        }

        await _mediator.Send(command, cancellationToken);

        return NoContent();
    }

    [HttpPost("{id:guid}/cancel")]
    public async Task<IActionResult> Cancel(
        Guid id,
        CancelLeaveRequestCommand command,
        CancellationToken cancellationToken)
    {
        if (id != command.LeaveRequestId)
        {
            return BadRequest("Route id does not match request id.");
        }

        await _mediator.Send(command, cancellationToken);

        return NoContent();
    }
}