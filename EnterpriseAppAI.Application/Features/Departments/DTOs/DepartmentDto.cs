namespace EnterpriseAppAI.Application.Features.Departments.DTOs;

/// <summary>
/// API-facing representation of a Department. Shaped for consumers, not the database -
/// e.g. Name is included here.
/// </summary>
public class DepartmentDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public string Code { get; set; } = string.Empty;

    public bool IsActive { get; set; }
}


