using EnterpriseAppAI.Application.Features.Employees.DTOs;
using EnterpriseAppAI.Application.Features.Employees.Queries.GetEmployeeById;
using EnterpriseAppAI.Infrastructure.AI.Abstractions;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.SemanticKernel;
using System.ComponentModel;

namespace EnterpriseAppAI.Infrastructure.AI.Plugins
{
    public sealed class EmployeePlugin : IAIPlugin
    {
        private readonly IMediator _mediator;
        private readonly ILogger<EmployeePlugin> _logger;

        public EmployeePlugin(IMediator mediator, ILogger<EmployeePlugin> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [KernelFunction]
        [Description("Retrieves employee information using the employee's unique identifier. Returns employee number, full name, email, department and active status.")]
        public async Task<EmployeeDto> GetEmployeeByIdAsync([Description("The unique identifier (GUID) of the employee.")] Guid employeeId, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation(
           "EmployeePlugin.GetEmployeeByIdAsync called with EmployeeId {EmployeeId}",
           employeeId);

            return await _mediator.Send(
                new GetEmployeeByIdQuery(employeeId),
                cancellationToken);
        }
    }
}
