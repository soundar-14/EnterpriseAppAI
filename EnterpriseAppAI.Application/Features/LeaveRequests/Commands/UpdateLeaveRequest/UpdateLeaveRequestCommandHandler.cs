using EnterpriseAppAI.Application.Common.Exceptions;
using EnterpriseAppAI.Application.Features.LeaveRequests.DTOs;
using EnterpriseAppAI.Application.Features.LeaveRequests.Mappings;
using EnterpriseAppAI.Application.Interfaces.Persistence;
using EnterpriseAppAI.Domain.Entities;
using EnterpriseAppAI.Domain.Enums;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EnterpriseAppAI.Application.Features.LeaveRequests.Commands.UpdateLeaveRequest;

public sealed class UpdateLeaveRequestCommandHandler
    : IRequestHandler<UpdateLeaveRequestCommand, LeaveRequestDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<UpdateLeaveRequestCommandHandler> _logger;

    public UpdateLeaveRequestCommandHandler(
        IUnitOfWork unitOfWork,
        ILogger<UpdateLeaveRequestCommandHandler> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task<LeaveRequestDto> Handle(
        UpdateLeaveRequestCommand request,
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
        // Only Pending leave can be updated
        if (leave.Status != LeaveStatus.Pending)
        {
            throw new BusinessRuleException(
                $"Only Pending leave requests can be updated. Current status: {leave.Status}");
        }

        // Business Rule 2
        if (request.EndDate < request.StartDate)
        {
            throw new BusinessRuleException(
                "End date cannot be earlier than Start date.");
        }

        // Business Rule 3
        // Check overlapping leaves except this leave request
        var existingLeaves = await repository.FindAsync(
            x =>
                x.EmployeeId == leave.EmployeeId &&
                x.Id != leave.Id &&
                x.Status != LeaveStatus.Rejected &&
                x.Status != LeaveStatus.Cancelled,
            cancellationToken);

        var hasOverlap = existingLeaves.Any(x =>
            request.StartDate <= x.EndDate &&
            request.EndDate >= x.StartDate);

        if (hasOverlap)
        {
            throw new BusinessRuleException(
                "Employee already has another leave during the selected period.");
        }

        // Business Rule 4
        var totalDays =
            request.EndDate.DayNumber -
            request.StartDate.DayNumber + 1;

        // Update entity
        leave.LeaveType = request.LeaveType;
        leave.StartDate = request.StartDate;
        leave.EndDate = request.EndDate;
        leave.TotalDays = totalDays;
        leave.Reason = request.Reason;

        repository.Update(leave);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        _logger.LogInformation(
            "Leave request {LeaveId} updated.",
            leave.Id);

        return leave.ToDto();
    }
}