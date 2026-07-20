using EnterpriseAppAI.Application.Interfaces.Persistence;
using EnterpriseAppAI.Domain.Entities;
using MediatR;

namespace EnterpriseAppAI.Application.Features.Employees.Commands.UpdateEmployee;

public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateEmployeeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.Repository<Employee>();
        var employee = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (employee is null)
        {
            return false;
        }

        employee.FirstName = request.FirstName;
        employee.LastName = request.LastName;
        employee.Email = request.Email;
        employee.DepartmentId = request.DepartmentId;
        employee.IsActive = request.IsActive;

        repository.Update(employee);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }
}
