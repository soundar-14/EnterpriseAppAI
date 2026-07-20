using EnterpriseAppAI.Application.Features.Employees.DTOs;
using EnterpriseAppAI.Application.Features.Employees.Mappings;
using EnterpriseAppAI.Application.Interfaces.Persistence;
using EnterpriseAppAI.Domain.Entities;
using MediatR;

namespace EnterpriseAppAI.Application.Features.Employees.Queries.GetEmployeeById;

public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeDto?>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetEmployeeByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<EmployeeDto?> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
    {
        var employee = await _unitOfWork.Repository<Employee>().GetByIdAsync(request.Id, cancellationToken);

        return employee?.ToDto();
    }
}
