using EnterpriseAppAI.Application.Features.Employees.DTOs;
using EnterpriseAppAI.Application.Features.Employees.Queries.GetEmployeeById;
using MediatR;
using Microsoft.SemanticKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace EnterpriseAppAI.Infrastructure.AI.Plugins
{
    public sealed class EmployeePlugin
    {
        private readonly IMediator _mediator;

        public EmployeePlugin(IMediator mediator)
        {
            _mediator = mediator;
        }

        [KernelFunction]
        [Description("Retrieves employee information using the employee's unique identifier. Returns employee number, full name, email, department and active status.")]
        public async Task<EmployeeDto> GetEmployeeByIdAsync([Description("The unique identifier (GUID) of the employee.")] Guid employeeId, CancellationToken cancellationToken = default)
        {
            return await _mediator.Send(
                new GetEmployeeByIdQuery(employeeId),
                cancellationToken);
        }
    }
}
