using EnterpriseAppAI.Application.Common.Exceptions;
using EnterpriseAppAI.Application.Features.LeaveRequests.DTOs;
using EnterpriseAppAI.Application.Features.LeaveRequests.Mappings;
using EnterpriseAppAI.Application.Interfaces.Persistence;
using EnterpriseAppAI.Domain.Entities;
using EnterpriseAppAI.Domain.Enums;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EnterpriseAppAI.Application.Features.LeaveRequests.Commands.CreateLeaveRequest;

public sealed class CreateLeaveRequestCommandHandler
    : IRequestHandler<CreateLeaveRequestCommand, LeaveRequestDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<CreateLeaveRequestCommandHandler> _logger;

    public CreateLeaveRequestCommandHandler(
        IUnitOfWork unitOfWork,
        ILogger<CreateLeaveRequestCommandHandler> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task<LeaveRequestDto> Handle(
        CreateLeaveRequestCommand request,
        CancellationToken cancellationToken)
    {
        // Repository references
        var employeeRepository = _unitOfWork.Repository<Employee>();
        var leaveRepository = _unitOfWork.Repository<LeaveRequest>();

        // ======================================================
        // Business Rule 1
        // Employee must exist
        // ======================================================

        var employee = await employeeRepository.GetByIdAsync(
            request.EmployeeId,
            cancellationToken);

        if (employee is null)
        {
            throw new NotFoundException(
                nameof(Employee),
                request.EmployeeId);
        }

        // ======================================================
        // Business Rule 2
        // End Date >= Start Date
        // (Extra validation for safety)
        // ======================================================

        if (request.EndDate < request.StartDate)
        {
            throw new BusinessRuleException(
                "End date cannot be earlier than Start date.");
        }

        // ======================================================
        // Business Rule 3
        // Employee cannot apply overlapping leave
        // ======================================================

        var existingLeaves = await leaveRepository.FindAsync(
            x =>
                x.EmployeeId == request.EmployeeId &&
                x.Status != LeaveStatus.Rejected &&
                x.Status != LeaveStatus.Cancelled,
            cancellationToken);

        var hasOverlap = existingLeaves.Any(x =>
            request.StartDate <= x.EndDate &&
            request.EndDate >= x.StartDate);

        if (hasOverlap)
        {
            throw new BusinessRuleException(
                "Employee already has leave during the selected period.");
        }

        // ======================================================
        // Business Rule 4
        // Calculate total leave days
        // ======================================================

        var totalDays =
            request.EndDate.DayNumber -
            request.StartDate.DayNumber + 1;

        // ======================================================
        // Create entity
        // ======================================================

        var leaveRequest = new LeaveRequest
        {
            EmployeeId = request.EmployeeId,
            LeaveType = request.LeaveType,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            TotalDays = totalDays,
            Reason = request.Reason,
            Status = LeaveStatus.Pending
        };

        await leaveRepository.AddAsync(
            leaveRequest,
            cancellationToken);

        await _unitOfWork.SaveChangesAsync(
            cancellationToken);

        _logger.LogInformation(
            "Leave request {LeaveId} created for Employee {EmployeeId}",
            leaveRequest.Id,
            leaveRequest.EmployeeId);

        // Populate navigation property for mapping
        leaveRequest.Employee = employee;

        return leaveRequest.ToDto();
    }
}