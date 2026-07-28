using EnterpriseAppAI.Application.Common.Exceptions;
using EnterpriseAppAI.Application.Interfaces.Persistence;
using EnterpriseAppAI.Domain.Entities;
using EnterpriseAppAI.Domain.Enums;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EnterpriseAppAI.Application.Features.LeaveRequests.Commands.RejectLeaveRequest;

public sealed class RejectLeaveRequestCommandHandler
    : IRequestHandler<RejectLeaveRequestCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<RejectLeaveRequestCommandHandler> _logger;

    public RejectLeaveRequestCommandHandler(
        IUnitOfWork unitOfWork,
        ILogger<RejectLeaveRequestCommandHandler> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task<bool> Handle(
        RejectLeaveRequestCommand request,
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

        if (leave.Status != LeaveStatus.Pending)
        {
            throw new BusinessRuleException(
                $"Only Pending leave requests can be rejected. Current status: {leave.Status}");
        }

        if (string.IsNullOrWhiteSpace(request.ManagerComments))
        {
            throw new BusinessRuleException(
                "Manager comments are required when rejecting a leave request.");
        }

        leave.Status = LeaveStatus.Rejected;
        leave.ApprovedBy = request.RejectedBy;
        leave.ApprovedOn = DateTime.UtcNow;
        leave.ManagerComments = request.ManagerComments;

        repository.Update(leave);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        _logger.LogInformation(
            "Leave request {LeaveId} rejected by {ManagerId}",
            leave.Id,
            request.RejectedBy);

        return true;
    }
}