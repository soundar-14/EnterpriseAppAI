using Microsoft.Extensions.Logging;
using Microsoft.SemanticKernel;
using ModelContextProtocol.Client;

namespace EnterpriseAppAI.Infrastructure.AI.MCP;

public sealed class McpKernelPluginFactory
{
    private readonly IMcpClientService _mcpClientService;
    private readonly ILogger<McpKernelPluginFactory> _logger;

    public McpKernelPluginFactory(
        IMcpClientService mcpClientService,
        ILogger<McpKernelPluginFactory> logger)
    {
        _mcpClientService = mcpClientService;
        _logger = logger;
    }

    public async Task<KernelPlugin> CreatePluginAsync(
        string pluginName,
        CancellationToken cancellationToken = default)
    {
        // ============================================================
        // MCP TOOLS
        // ============================================================

        var tools = await _mcpClientService.GetToolsAsync(
            cancellationToken);

        _logger.LogInformation(
            "MCP tools discovered: {Tools}",
            string.Join(", ", tools.Select(x => x.Name)));

        var functions = new List<KernelFunction>();

        foreach (var tool in tools)
        {
            var function = CreateKernelFunction(tool);
            functions.Add(function);
        }


        // ============================================================
        // MCP RESOURCE
        // ============================================================

        var resourceFunction = KernelFunctionFactory.CreateFromMethod(
            async (
                string resourceUri,
                CancellationToken resourceCancellationToken) =>
            {
                _logger.LogInformation(
                    "MCP RESOURCE CALLED: {ResourceUri}",
                    resourceUri);

                var result =
                    await _mcpClientService.ReadResourceAsync(
                        resourceUri,
                        resourceCancellationToken);

                _logger.LogInformation(
                    "MCP RESOURCE RESULT RECEIVED: {ResourceUri}",
                    resourceUri);

                return result;
            },
            "read_mcp_resource",
            "Reads an MCP resource using its resource URI.",
            new[]
            {
                new KernelParameterMetadata("resourceUri")
                {
                    Description =
                        "The URI of the MCP resource to read, for example hrpolicy://policy.",
                    IsRequired = true
                }
            });

        functions.Add(resourceFunction);


        // ============================================================
        // MCP PROMPT
        // ============================================================

        var promptFunction = KernelFunctionFactory.CreateFromMethod(
            async (
                string promptName,
                CancellationToken promptCancellationToken) =>
            {
                _logger.LogInformation(
                    "MCP PROMPT CALLED: {PromptName}",
                    promptName);

                var result =
                    await _mcpClientService.GetPromptAsync(
                        promptName,
                        null,
                        promptCancellationToken);

                _logger.LogInformation(
                    "MCP PROMPT RESULT RECEIVED: {PromptName}",
                    promptName);

                return result;
            },
            "get_mcp_prompt",
            "Gets an MCP prompt by its prompt name.",
            new[]
            {
                new KernelParameterMetadata("promptName")
                {
                    Description =
                        "The name of the MCP prompt, for example hr_assistant.",
                    IsRequired = true
                }
            });

        functions.Add(promptFunction);


        // ============================================================
        // CREATE SK PLUGIN
        // ============================================================

        return KernelPluginFactory.CreateFromFunctions(
            pluginName,
            functions);
    }


    // ================================================================
    // MCP TOOL -> SK FUNCTION
    // ================================================================

    private KernelFunction CreateKernelFunction(
        McpClientTool tool)
    {
        var parameters = new List<KernelParameterMetadata>();

        if (tool.JsonSchema.ValueKind ==
            System.Text.Json.JsonValueKind.Object &&
            tool.JsonSchema.TryGetProperty(
                "properties",
                out var properties))
        {
            foreach (var property in properties.EnumerateObject())
            {
                var parameterName = property.Name;

                var description =
                    property.Value.TryGetProperty(
                        "description",
                        out var descriptionElement)
                        ? descriptionElement.GetString()
                        : null;

                parameters.Add(
                    new KernelParameterMetadata(parameterName)
                    {
                        Description = description,
                        IsRequired = true
                    });
            }
        }

        return KernelFunctionFactory.CreateFromMethod(
            async (
                KernelArguments arguments,
                CancellationToken cancellationToken) =>
            {
                _logger.LogInformation(
                    "MCP TOOL CALLED: {ToolName}",
                    tool.Name);

                var toolArguments = arguments.ToDictionary(
                    x => x.Key,
                    x => x.Value);

                _logger.LogInformation(
                    "MCP TOOL ARGUMENTS: {@Arguments}",
                    toolArguments);

                var result =
                    await _mcpClientService.CallToolAsync(
                        tool.Name,
                        toolArguments,
                        cancellationToken);

                _logger.LogInformation(
                    "MCP TOOL RESULT RECEIVED: {ToolName}",
                    tool.Name);

                return result;
            },
            tool.Name,
            tool.Description,
            parameters);
    }
}