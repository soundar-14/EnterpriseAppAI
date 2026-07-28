namespace EnterpriseAppAI.Domain.Enums;

/// <summary>
/// Current approval status of a leave request.
/// </summary>
public enum LeaveStatus
{
    Pending = 1,

    Approved = 2,

    Rejected = 3,

    Cancelled = 4
}