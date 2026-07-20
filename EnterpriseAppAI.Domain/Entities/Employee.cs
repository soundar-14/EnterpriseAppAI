using EnterpriseAppAI.Domain.Common;

namespace EnterpriseAppAI.Domain.Entities;

/// <summary>
/// Represents an employee. DepartmentId is a plain foreign key reference (no
/// navigation property) - relationships are introduced in the EF Core milestone.
/// </summary>
public class Employee : BaseEntity
{
    public string EmployeeNumber { get; set; } = string.Empty;

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public Guid DepartmentId { get; set; }

    public bool IsActive { get; set; } = true;
}
