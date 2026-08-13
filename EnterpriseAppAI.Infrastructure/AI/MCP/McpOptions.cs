namespace EnterpriseAppAI.Infrastructure.AI.MCP;

public sealed class McpOptions
{
    public const string SectionName = "Mcp";

    public string ServerUrl { get; set; } = string.Empty;
}