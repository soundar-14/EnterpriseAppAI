using EnterpriseAppAI.Application.Features.Departments.DTOs;
using EnterpriseAppAI.Application.Features.Departments.Queries.GetDepartmentById;
using EnterpriseAppAI.Infrastructure.AI.Abstractions;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.SemanticKernel;
using System.ComponentModel;

namespace EnterpriseAppAI.Infrastructure.AI.Plugins
{
    public sealed class DepartmentPlugin : IAIPlugin
    {
        private readonly IMediator _mediator;
        private readonly ILogger<EmployeePlugin> _logger;

        public DepartmentPlugin(IMediator mediator, ILogger<EmployeePlugin> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [KernelFunction]
        [Description("Retrieves department information using the department's unique identifier. Returns department number, full name, email, department and active status.")]
        public async Task<DepartmentDto> GetDepartmentByIdAsync([Description("The unique identifier (GUID) of the department.")] Guid departmentId, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation(
           "DepartmentPlugin.GetDepartmentByIdAsync called with DepartmentId {DepartmentId}",
           departmentId);

            return await _mediator.Send(
                new GetDepartmentByIdQuery(departmentId),
                cancellationToken);
        }
    }
}
