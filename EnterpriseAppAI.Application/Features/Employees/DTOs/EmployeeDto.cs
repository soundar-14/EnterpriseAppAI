namespace EnterpriseAppAI.Application.Features.Employees.DTOs;

/// <summary>
/// API-facing representation of an Employee. Shaped for consumers, not the database -
/// e.g. FirstName/LastName are combined into FullName here.
/// </summary>
public class EmployeeDto
{
    public Guid Id { get; set; }

    public string EmployeeNumber { get; set; } = string.Empty;

    public string FullName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public Guid DepartmentId { get; set; }

    public bool IsActive { get; set; }
}
