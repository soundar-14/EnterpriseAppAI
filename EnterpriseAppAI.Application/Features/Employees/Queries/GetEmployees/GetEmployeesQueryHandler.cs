using EnterpriseAppAI.Application.Features.Employees.DTOs;
using EnterpriseAppAI.Application.Features.Employees.Mappings;
using EnterpriseAppAI.Application.Interfaces.Persistence;
using EnterpriseAppAI.Domain.Entities;
using MediatR;

namespace EnterpriseAppAI.Application.Features.Employees.Queries.GetEmployees;

public class GetEmployeesQueryHandler : IRequestHandler<GetEmployeesQuery, IReadOnlyList<EmployeeDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetEmployeesQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IReadOnlyList<EmployeeDto>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
    {
        var employees = await _unitOfWork.Repository<Employee>().GetAllAsync(cancellationToken);

        return employees.Select(e => e.ToDto()).ToList();
    }
}
