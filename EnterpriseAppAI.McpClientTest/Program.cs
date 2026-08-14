using ModelContextProtocol.Client;
using System.Text.Json;

var serverUrl = "http://localhost:5259/mcp";

var transport = new HttpClientTransport(
    new HttpClientTransportOptions
    {
        Endpoint = new Uri(serverUrl),
        Name = "EnterpriseAppAI MCP Client",
        TransportMode = HttpTransportMode.StreamableHttp
    });

await using var client = await McpClient.CreateAsync(transport);

Console.WriteLine("Connected to MCP Server.");


var tools = await client.ListToolsAsync();

Console.WriteLine();
Console.WriteLine("Available MCP Tools:");

foreach (var tool in tools)
{
    Console.WriteLine($"Name        : {tool.Name}");
    Console.WriteLine($"Description : {tool.Description}");

    Console.WriteLine("Input Schema:");

    Console.WriteLine(
        JsonSerializer.Serialize(
            tool.JsonSchema,
            new JsonSerializerOptions
            {
                WriteIndented = true
            }));

    Console.WriteLine();
}

Console.WriteLine();
Console.WriteLine("Calling get_employee_leave_history...");

var result = await client.CallToolAsync(
    "get_employee_leave_history_mcp",
    new Dictionary<string, object?>
    {
        ["employeeId"] = "9F1A23B4-C56D-78E9-0123-456789ABCDEF"
    });

Console.WriteLine();
Console.WriteLine("Tool Result:");

foreach (var content in result.Content)
{
    Console.WriteLine(content);
}

// ============================================================
// JIRA MCP TOOL
// ============================================================

Console.WriteLine();
Console.WriteLine("Calling get_jira_issue...");

var jiraResult = await client.CallToolAsync(
    "get_jira_issue",
    new Dictionary<string, object?>
    {
        ["issueKey"] = "EPMCDMETST-42534"
    });

Console.WriteLine();
Console.WriteLine("Jira Tool Result:");

foreach (var content in jiraResult.Content)
{
    Console.WriteLine(content);
}

 //============================================================
 //GITHUB MCP TOOL
 //============================================================

Console.WriteLine();
Console.WriteLine("Calling GitHub MCP tool...");

var githubResult = await client.CallToolAsync(
    "get_git_hub_repository",
    new Dictionary<string, object?>
    {
        ["owner"] = "soundar-14",
        ["repository"] = "FeatureGate.App"
    });

Console.WriteLine();
Console.WriteLine("GitHub Result:");

foreach (var content in githubResult.Content)
{
    Console.WriteLine(content);
}

Console.WriteLine();
Console.WriteLine("Available MCP Resources:");

var resources = await client.ListResourcesAsync();

foreach (var resource in resources)
{
    Console.WriteLine(
        $"- {resource.Uri}: {resource.Name}");
}


Console.WriteLine();
Console.WriteLine("Reading HR Policy Resource...");

var readResource = await client.ReadResourceAsync(
    "hrpolicy://policy");

Console.WriteLine();
Console.WriteLine("HR Policy Content:");

foreach (var content in readResource.Contents)
{
    Console.WriteLine(content);
}

Console.WriteLine();
Console.WriteLine("Reading Employee Resource...");

var employeeResource = await client.ReadResourceAsync(
    "employee://9f1a23b4-c56d-78e9-0123-456789abcdef");

Console.WriteLine();
Console.WriteLine("Employee Resource Content:");

foreach (var content in employeeResource.Contents)
{
    Console.WriteLine(content);
}

Console.WriteLine();
Console.WriteLine("Available MCP Prompts:");

var prompts = await client.ListPromptsAsync();

foreach (var prompt in prompts)
{
    Console.WriteLine($"- {prompt.Name}");
}

Console.WriteLine();
Console.WriteLine("Getting HR Assistant Prompt...");

var getPrompt = await client.GetPromptAsync("hr_assistant");

Console.WriteLine();
Console.WriteLine("HR Assistant Prompt:");

foreach (var message in getPrompt.Messages)
{
    Console.WriteLine(message.Content);
}

