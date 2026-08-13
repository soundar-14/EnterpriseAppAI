using System.ComponentModel;
using Microsoft.SemanticKernel;

namespace EnterpriseAppAI.Infrastructure.AI.MCP;

public sealed class McpContextPlugin
{
    private readonly McpSemanticKernelService _mcpService;

    public McpContextPlugin(
        McpSemanticKernelService mcpService)
    {
        _mcpService = mcpService;
    }

    [KernelFunction("read_mcp_resource")]
    [Description(
        "Reads information from an MCP resource using its URI. " +
        "Use this when information is stored as an MCP resource.")]
    public async Task<string> ReadResourceAsync(
        [Description("The MCP resource URI, for example hrpolicy://policy.")]
        string resourceUri,
        CancellationToken cancellationToken = default)
    {
        return await _mcpService.ReadResourceAsync(
            resourceUri,
            cancellationToken);
    }

    [KernelFunction("get_mcp_prompt")]
    [Description(
        "Gets a prompt template from the MCP server.")]
    public async Task<string> GetPromptAsync(
        [Description("The MCP prompt name.")]
        string promptName,
        CancellationToken cancellationToken = default)
    {
        return await _mcpService.GetPromptAsync(
            promptName,
            null,
            cancellationToken);
    }
}