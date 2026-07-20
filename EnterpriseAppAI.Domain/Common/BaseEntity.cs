namespace EnterpriseAppAI.Domain.Common;

/// <summary>
/// Base class for all Domain entities. Provides identity and audit tracking.
/// Contains no Entity Framework Core or ASP.NET Core dependencies.
/// </summary>
public abstract class BaseEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public string? UpdatedBy { get; set; }

    public bool IsDeleted { get; set; }
}
