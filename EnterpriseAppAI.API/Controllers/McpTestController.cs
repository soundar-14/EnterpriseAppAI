using EnterpriseAppAI.Infrastructure.AI.MCP;
using Microsoft.AspNetCore.Mvc;
using Microsoft.SemanticKernel;

namespace EnterpriseAppAI.API.Controllers;

[ApiController]
[Route("api/mcp-test")]
public class McpTestController : ControllerBase
{
    private readonly IMcpClientService _mcpClient;

    public McpTestController(IMcpClientService mcpClient)
    {
        _mcpClient = mcpClient;
    }

    [HttpGet("tools")]
    public async Task<IActionResult> GetTools()
    {
        var tools = await _mcpClient.GetToolsAsync();

        return Ok(tools.Select(t => new
        {
            t.Name,
            t.Description
        }));
    }

    [HttpGet("leave-history/{employeeId:guid}")]
    public async Task<IActionResult> GetLeaveHistory(
    Guid employeeId,
    CancellationToken cancellationToken)
    {
        var arguments = new Dictionary<string, object?>
        {
            ["employeeId"] = employeeId.ToString()
        };

        var result = await _mcpClient.CallToolAsync(
            "get_employee_leave_history",
            arguments,
            cancellationToken);

        return Ok(result);
    }

    [HttpGet("mcp-tools")]
    public async Task<IActionResult> GetMcpTools(
    [FromServices] Kernel kernel,
    [FromServices] McpSemanticKernelService mcpService,
    CancellationToken cancellationToken)
    {
        await mcpService.AddMcpPluginsAsync(
            kernel,
            cancellationToken);

        var functions = kernel.Plugins
            .SelectMany(plugin => plugin)
            .Select(function => new
            {
                Plugin = function.PluginName,
                Name = function.Name,
                Description = function.Description
            });

        return Ok(functions);
    }
}