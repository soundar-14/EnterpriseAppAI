using Microsoft.Extensions.Logging;
using Microsoft.SemanticKernel;

namespace EnterpriseAppAI.Infrastructure.AI.MCP;

public sealed class McpSemanticKernelService
{
    private readonly McpKernelPluginFactory _pluginFactory;
    private readonly IMcpClientService _mcpClientService;
    private readonly ILogger<McpSemanticKernelService> _logger;

    public McpSemanticKernelService(
        McpKernelPluginFactory pluginFactory,
        IMcpClientService mcpClientService,
        ILogger<McpSemanticKernelService> logger)
    {
        _pluginFactory = pluginFactory;
        _mcpClientService = mcpClientService;
        _logger = logger;
    }

    // =========================================================
    // MCP TOOLS -> SEMANTIC KERNEL
    // =========================================================

    public async Task AddMcpPluginsAsync(
        Kernel kernel,
        CancellationToken cancellationToken = default)
    {
        var plugin = await _pluginFactory.CreatePluginAsync(
            "McpTools",
            cancellationToken);

        kernel.Plugins.Add(plugin);

        _logger.LogInformation(
            "MCP Tools plugin added to Semantic Kernel: {PluginName}",
            plugin.Name);
    }

    // =========================================================
    // MCP RESOURCE
    // =========================================================

    public async Task<string> ReadResourceAsync(
        string resourceUri,
        CancellationToken cancellationToken = default)
    {
        _logger.LogInformation(
            "MCP RESOURCE REQUEST: {ResourceUri}",
            resourceUri);

        var result = await _mcpClientService.ReadResourceAsync(
            resourceUri,
            cancellationToken);

        _logger.LogInformation(
            "MCP RESOURCE RESPONSE RECEIVED: {ResourceUri}",
            resourceUri);

        return result;
    }

    // =========================================================
    // MCP PROMPT
    // =========================================================

    public async Task<string> GetPromptAsync(
        string promptName,
        IReadOnlyDictionary<string, object?>? arguments = null,
        CancellationToken cancellationToken = default)
    {
        _logger.LogInformation(
            "MCP PROMPT REQUEST: {PromptName}",
            promptName);

        var result = await _mcpClientService.GetPromptAsync(
            promptName,
            arguments,
            cancellationToken);

        _logger.LogInformation(
            "MCP PROMPT RESPONSE RECEIVED: {PromptName}",
            promptName);

        return result;
    }
}