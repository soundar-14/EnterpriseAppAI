using EnterpriseAppAI.Application.Features.Employees.Queries.GetEmployeeById;
using MediatR;
using ModelContextProtocol.Server;

namespace EnterpriseAppAI.McpServer.Resources;

[McpServerResourceType]
public sealed class EmployeeResource
{
    private readonly IMediator _mediator;

    public EmployeeResource(IMediator mediator)
    {
        _mediator = mediator;
    }

    [McpServerResource(
        UriTemplate = "employee://{employeeId}",
        Name = "Employee")]
    public async Task<string> GetEmployee(
        string employeeId,
        CancellationToken cancellationToken)
    {
        if (!Guid.TryParse(employeeId, out var id))
        {
            return "Invalid employee ID.";
        }

        var employee = await _mediator.Send(
            new GetEmployeeByIdQuery(id),
            cancellationToken);

        if (employee is null)
        {
            return "Employee not found.";
        }

        return $"""
                Employee Information

                Id: {employee.Id}
                Name: {employee.FullName}
                Email: {employee.Email}
                """;
    }
}