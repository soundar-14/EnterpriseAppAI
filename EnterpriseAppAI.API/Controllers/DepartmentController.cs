using EnterpriseAppAI.Application.Features.Departments.Commands.CreateDepartment;
using EnterpriseAppAI.Application.Features.Departments.Commands.DeleteDepartment;
using EnterpriseAppAI.Application.Features.Departments.Commands.UpdateDepartment;
using EnterpriseAppAI.Application.Features.Departments.Queries.GetDepartmentById;
using EnterpriseAppAI.Application.Features.Departments.Queries.GetDepartments;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EnterpriseAppAI.API.Controllers;

/// <summary>
/// Exposes Department CQRS handlers over REST. Contains no business logic - it only
/// sends commands/queries via MediatR and maps their results to HTTP responses.
/// </summary>
[ApiController]
[Route("api/departments")]
[Authorize]
public class DepartmentController : ControllerBase
{
    private readonly IMediator _mediator;

    public DepartmentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var departments = await _mediator.Send(new GetDepartmentsQuery(), cancellationToken);
        return Ok(departments);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        var Department = await _mediator.Send(new GetDepartmentByIdQuery(id), cancellationToken);
        return Ok(Department);
    }

    [HttpPost]
    [Authorize(Policy = "AdminOnly")]
    public async Task<IActionResult> Create(CreateDepartmentCommand command, CancellationToken cancellationToken)
    {
        var id = await _mediator.Send(command, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }

    [HttpPut("{id:guid}")]
    [Authorize(Policy = "AdminOnly")]
    public async Task<IActionResult> Update(Guid id, UpdateDepartmentCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command with { Id = id }, cancellationToken);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Policy = "AdminOnly")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _mediator.Send(new DeleteDepartmentCommand(id), cancellationToken);
        return NoContent();
    }
}
