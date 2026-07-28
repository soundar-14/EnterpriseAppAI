using EnterpriseAppAI.Application.Common.Exceptions;
using EnterpriseAppAI.Application.Interfaces.Persistence;
using EnterpriseAppAI.Domain.Entities;
using EnterpriseAppAI.Domain.Enums;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EnterpriseAppAI.Application.Features.LeaveRequests.Commands.ApproveLeaveRequest;

public sealed class ApproveLeaveRequestCommandHandler
    : IRequestHandler<ApproveLeaveRequestCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<ApproveLeaveRequestCommandHandler> _logger;

    public ApproveLeaveRequestCommandHandler(
        IUnitOfWork unitOfWork,
        ILogger<ApproveLeaveRequestCommandHandler> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task<bool> Handle(
        ApproveLeaveRequestCommand request,
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

        // Business Rule 1
        if (leave.Status != LeaveStatus.Pending)
        {
            throw new BusinessRuleException(
                $"Only Pending leave requests can be approved. Current status: {leave.Status}");
        }

        // Business Rule 2
        leave.Status = LeaveStatus.Approved;

        leave.ApprovedBy = request.ApprovedBy;

        leave.ApprovedOn = DateTime.UtcNow;

        leave.ManagerComments = request.ManagerComments;

        repository.Update(leave);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        _logger.LogInformation(
            "Leave request {LeaveId} approved by {ManagerId}",
            leave.Id,
            request.ApprovedBy);

        return true;
    }
}