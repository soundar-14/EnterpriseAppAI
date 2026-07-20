using EnterpriseAppAI.Application.Features.Employees.Commands.CreateEmployee;
using EnterpriseAppAI.Application.Features.Employees.Commands.DeleteEmployee;
using EnterpriseAppAI.Application.Features.Employees.Commands.UpdateEmployee;
using EnterpriseAppAI.Application.Features.Employees.Queries.GetEmployeeById;
using EnterpriseAppAI.Application.Features.Employees.Queries.GetEmployees;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EnterpriseAppAI.API.Controllers;

/// <summary>
/// Exposes Employee CQRS handlers over REST. Contains no business logic - it only
/// sends commands/queries via MediatR and maps their results to HTTP responses.
/// </summary>
[ApiController]
[Route("api/employees")]
[Authorize]
public class EmployeeController : ControllerBase
{
    private readonly IMediator _mediator;

    public EmployeeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var employees = await _mediator.Send(new GetEmployeesQuery(), cancellationToken);
        return Ok(employees);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        var employee = await _mediator.Send(new GetEmployeeByIdQuery(id), cancellationToken);
        return Ok(employee);
    }

    [HttpPost]
    [Authorize(Policy = "AdminOnly")]
    public async Task<IActionResult> Create(CreateEmployeeCommand command, CancellationToken cancellationToken)
    {
        var id = await _mediator.Send(command, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }

    [HttpPut("{id:guid}")]
    [Authorize(Policy = "AdminOnly")]
    public async Task<IActionResult> Update(Guid id, UpdateEmployeeCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command with { Id = id }, cancellationToken);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Policy = "AdminOnly")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _mediator.Send(new DeleteEmployeeCommand(id), cancellationToken);
        return NoContent();
    }
}
