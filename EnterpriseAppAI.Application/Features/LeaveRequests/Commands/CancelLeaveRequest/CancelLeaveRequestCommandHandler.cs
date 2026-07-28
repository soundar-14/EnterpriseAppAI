using EnterpriseAppAI.Application.Common.Exceptions;
using EnterpriseAppAI.Application.Interfaces.Persistence;
using EnterpriseAppAI.Domain.Entities;
using EnterpriseAppAI.Domain.Enums;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EnterpriseAppAI.Application.Features.LeaveRequests.Commands.CancelLeaveRequest;

public sealed class CancelLeaveRequestCommandHandler
    : IRequestHandler<CancelLeaveRequestCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<CancelLeaveRequestCommandHandler> _logger;

    public CancelLeaveRequestCommandHandler(
        IUnitOfWork unitOfWork,
        ILogger<CancelLeaveRequestCommandHandler> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task<bool> Handle(
        CancelLeaveRequestCommand request,
        CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.Repository<LeaveRequest>();

        var leave = await repository.GetByIdAsync(
            request.LeaveRequestId,
            cancellationToken);

        if (leave is null)
        {
            throw new NotFoundException(
                nameof(LeaveRequest),
                request.LeaveRequestId);
        }

        // Only the employee who created the leave can cancel it
        if (leave.EmployeeId != request.EmployeeId)
        {
            throw new BusinessRuleException(
                "Only the employee who created the leave request can cancel it.");
        }

        // Only Pending leave can be cancelled
        if (leave.Status != LeaveStatus.Pending)
        {
            throw new BusinessRuleException(
                $"Only Pending leave requests can be cancelled. Current status: {leave.Status}");
        }

        leave.Status = LeaveStatus.Cancelled;

        repository.Update(leave);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        _logger.LogInformation(
            "Leave request {LeaveId} cancelled by employee {EmployeeId}",
            leave.Id,
            request.EmployeeId);

        return true;
    }
}