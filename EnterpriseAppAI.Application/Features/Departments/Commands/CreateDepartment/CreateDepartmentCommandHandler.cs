using EnterpriseAppAI.Application.Common.Exceptions;
using EnterpriseAppAI.Application.Interfaces.Persistence;
using EnterpriseAppAI.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EnterpriseAppAI.Application.Features.Departments.Commands.CreateDepartment;

public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<CreateDepartmentCommandHandler> _logger;

    public CreateDepartmentCommandHandler(IUnitOfWork unitOfWork, ILogger<CreateDepartmentCommandHandler> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task<Guid> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.Repository<Department>();

        if (await repository.ExistsAsync(e => e.Name == request.Name, cancellationToken))
        {
            throw new ConflictException($"An department name is \"{request.Name}\" already exists.");
        }

        if (await repository.ExistsAsync(e => e.Code == request.Code, cancellationToken))
        {
            throw new ConflictException($"An department Code is \"{request.Code}\" already exists.");
        }

        var department = new Department
        {
            Name = request.Name,
            Code = request.Code,
            IsActive = true
        };

        await repository.AddAsync(department, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        _logger.LogInformation("Department {DepartmentId} created", department.Id);

        return department.Id;
    }
}
