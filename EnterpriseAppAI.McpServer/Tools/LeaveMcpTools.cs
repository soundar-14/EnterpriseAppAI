using EnterpriseAppAI.Infrastructure.AI.Plugins;
using ModelContextProtocol.Server;
using System.ComponentModel;
using System.Text.Json;

namespace EnterpriseAppAI.McpServer.Tools;

[McpServerToolType]
public sealed class LeaveMcpTools
{
    private readonly LeavePlugin _leavePlugin;

    public LeaveMcpTools(LeavePlugin leavePlugin)
    {
        _leavePlugin = leavePlugin;
    }

    [McpServerTool]
    [Description("Gets all leave requests for an employee.")]
    public async Task<string> GetEmployeeLeaveHistoryMcpAsync(
        [Description("The employee unique identifier.")]
        Guid employeeId,
        CancellationToken cancellationToken = default)
    {
        var result = await _leavePlugin.GetEmployeeLeaveHistoryAsync(
            employeeId,
            cancellationToken);

        return JsonSerializer.Serialize(result);
    }
}