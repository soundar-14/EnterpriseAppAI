using ModelContextProtocol.Client;

namespace EnterpriseAppAI.Infrastructure.AI.MCP;

public sealed class McpClientService : IMcpClientService
{
    private readonly McpClient _client;

    private McpClientService(McpClient client)
    {
        _client = client;
    }

    public static async Task<McpClientService> CreateAsync(
        string serverUrl,
        CancellationToken cancellationToken = default)
    {
        var transport = new HttpClientTransport(
            new HttpClientTransportOptions
            {
                Endpoint = new Uri(serverUrl),
                Name = "EnterpriseAppAI.API"
            });

        var client = await McpClient.CreateAsync(
            transport,
            cancellationToken: cancellationToken);

        return new McpClientService(client);
    }

    // ============================
    // TOOLS
    // ============================

    public async Task<IReadOnlyList<McpClientTool>> GetToolsAsync(
        CancellationToken cancellationToken = default)
    {
        var tools = await _client.ListToolsAsync(
            cancellationToken: cancellationToken);

        return tools.ToList();
    }

    public async Task<object> CallToolAsync(
        string toolName,
        IReadOnlyDictionary<string, object?> arguments,
        CancellationToken cancellationToken = default)
    {
        var result = await _client.CallToolAsync(
            toolName,
            arguments,
            cancellationToken: cancellationToken);

        return result;
    }

    // ============================
    // RESOURCES
    // ============================

    public async Task<string> ReadResourceAsync(
        string resourceUri,
        CancellationToken cancellationToken = default)
    {
        var result = await _client.ReadResourceAsync(
            resourceUri,
            cancellationToken: cancellationToken);

        return System.Text.Json.JsonSerializer.Serialize(
            result.Contents);
    }

    // ============================
    // PROMPTS
    // ============================

    public async Task<string> GetPromptAsync(
        string promptName,
        IReadOnlyDictionary<string, object?>? arguments = null,
        CancellationToken cancellationToken = default)
    {
        var result = await _client.GetPromptAsync(
            promptName,
            arguments,
            cancellationToken: cancellationToken);

        return System.Text.Json.JsonSerializer.Serialize(
            result.Messages);
    }
}