using EnterpriseAppAI.Domain.Common;
using EnterpriseAppAI.Domain.Enums;

namespace EnterpriseAppAI.Domain.Entities;

/// <summary>
/// Represents an employee leave request.
/// </summary>
public class LeaveRequest : BaseEntity
{
    /// <summary>
    /// Employee requesting leave.
    /// </summary>
    public Guid EmployeeId { get; set; }

    /// <summary>
    /// Leave type.
    /// </summary>
    public LeaveType LeaveType { get; set; }

    /// <summary>
    /// Leave start date.
    /// </summary>
    public DateOnly StartDate { get; set; }

    /// <summary>
    /// Leave end date.
    /// </summary>
    public DateOnly EndDate { get; set; }

    /// <summary>
    /// Total leave days.
    /// </summary>
    public int TotalDays { get; set; }

    /// <summary>
    /// Reason for leave.
    /// </summary>
    public string Reason { get; set; } = string.Empty;

    /// <summary>
    /// Approval status.
    /// </summary>
    public LeaveStatus Status { get; set; } = LeaveStatus.Pending;

    /// <summary>
    /// Manager comments.
    /// </summary>
    public string? ManagerComments { get; set; }

    /// <summary>
    /// Approved By.
    /// </summary>
    public Guid? ApprovedBy { get; set; }

    /// <summary>
    /// Approval date.
    /// </summary>
    public DateTime? ApprovedOn { get; set; }

    /// <summary>
    /// Navigation property.
    /// </summary>
    public Employee Employee { get; set; } = null!;
}