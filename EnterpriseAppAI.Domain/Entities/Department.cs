using EnterpriseAppAI.Domain.Common;

namespace EnterpriseAppAI.Domain.Entities;

/// <summary>
/// Represents an organizational department. No EF Core attributes or navigation
/// properties yet - those are introduced in the Infrastructure/EF Core milestone.
/// </summary>
public class Department : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public string Code { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;
}
