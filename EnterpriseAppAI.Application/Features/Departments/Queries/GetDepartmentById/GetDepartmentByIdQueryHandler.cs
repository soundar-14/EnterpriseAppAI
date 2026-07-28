using EnterpriseAppAI.Application.Common.Exceptions;
using EnterpriseAppAI.Application.Features.Departments.DTOs;
using EnterpriseAppAI.Application.Features.Departments.Mappings;
using EnterpriseAppAI.Application.Interfaces.Persistence;
using EnterpriseAppAI.Domain.Entities;
using MediatR;

namespace EnterpriseAppAI.Application.Features.Departments.Queries.GetDepartmentById    ;

public class GetDepartmentByIdQueryHandler : IRequestHandler<GetDepartmentByIdQuery, DepartmentDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetDepartmentByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<DepartmentDto> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
    {
        var department = await _unitOfWork.Repository<Department>().GetByIdAsync(request.Id, cancellationToken);

        return department?.ToDto() ?? throw new NotFoundException(nameof(Department), request.Id);
    }
}
