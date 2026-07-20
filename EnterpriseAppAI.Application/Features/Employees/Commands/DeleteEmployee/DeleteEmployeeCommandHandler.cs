using EnterpriseAppAI.Application.Interfaces.Persistence;
using EnterpriseAppAI.Domain.Entities;
using MediatR;

namespace EnterpriseAppAI.Application.Features.Employees.Commands.DeleteEmployee;

public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteEmployeeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.Repository<Employee>();
        var employee = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (employee is null)
        {
            return false;
        }

        repository.Delete(employee);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }
}
