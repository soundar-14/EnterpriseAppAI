using ModelContextProtocol.Client;

namespace EnterpriseAppAI.Infrastructure.AI.MCP;

public interface IMcpClientService
{
    // =========================
    // MCP TOOLS
    // =========================

    Task<IReadOnlyList<McpClientTool>> GetToolsAsync(
        CancellationToken cancellationToken = default);

    Task<object> CallToolAsync(
        string toolName,
        IReadOnlyDictionary<string, object?> arguments,
        CancellationToken cancellationToken = default);


    // =========================
    // MCP RESOURCES
    // =========================

    Task<string> ReadResourceAsync(
        string resourceUri,
        CancellationToken cancellationToken = default);


    // =========================
    // MCP PROMPTS
    // =========================

    Task<string> GetPromptAsync(
        string promptName,
        IReadOnlyDictionary<string, object?>? arguments = null,
        CancellationToken cancellationToken = default);
}