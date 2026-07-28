using EnterpriseAppAI.Domain.Entities;
using EnterpriseAppAI.Application.Features.Departments.DTOs;

namespace EnterpriseAppAI.Application.Features.Departments.Mappings;

/// <summary>
/// Manual Department -> DepartmentDto mapping. No AutoMapper yet, per Task 6 scope.
/// </summary>
public static class DepartmentMappings
{
    public static DepartmentDto ToDto(this Department department)
    {
        return new DepartmentDto
        {
            Id = department.Id,
            Name = department.Name,
            Code = department.Code,
            IsActive = department.IsActive
        };
    }
}
