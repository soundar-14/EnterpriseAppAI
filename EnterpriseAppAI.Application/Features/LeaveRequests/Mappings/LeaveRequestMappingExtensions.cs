using EnterpriseAppAI.Application.Features.LeaveRequests.DTOs;
using EnterpriseAppAI.Domain.Entities;

namespace EnterpriseAppAI.Application.Features.LeaveRequests.Mappings;

public static class LeaveRequestMappingExtensions
{
    public static LeaveRequestDto ToDto(this LeaveRequest entity)
    {
        return new LeaveRequestDto
        {
            Id = entity.Id,
            EmployeeId = entity.EmployeeId,
            EmployeeName = entity.Employee?.FullName ?? string.Empty,
            LeaveType = entity.LeaveType.ToString(),
            StartDate = entity.StartDate,
            EndDate = entity.EndDate,
            TotalDays = entity.TotalDays,
            Reason = entity.Reason,
            Status = entity.Status.ToString(),
            ManagerComments = entity.ManagerComments,
            ApprovedBy = entity.ApprovedBy,
            ApprovedOn = entity.ApprovedOn
        };
    }
}