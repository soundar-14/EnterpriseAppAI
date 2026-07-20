using EnterpriseAppAI.Domain.Entities;
using EnterpriseAppAI.Application.Features.Employees.DTOs;

namespace EnterpriseAppAI.Application.Features.Employees.Mappings;

/// <summary>
/// Manual Employee -> EmployeeDto mapping. No AutoMapper yet, per Task 6 scope.
/// </summary>
public static class EmployeeMappings
{
    public static EmployeeDto ToDto(this Employee employee)
    {
        return new EmployeeDto
        {
            Id = employee.Id,
            EmployeeNumber = employee.EmployeeNumber,
            FullName = $"{employee.FirstName} {employee.LastName}".Trim(),
            Email = employee.Email,
            DepartmentId = employee.DepartmentId,
            IsActive = employee.IsActive
        };
    }
}
