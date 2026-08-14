using EnterpriseAppAI.Application.DependencyInjection;
using EnterpriseAppAI.Infrastructure.DependencyInjection;
using EnterpriseAppAI.McpServer.Configuration;
using EnterpriseAppAI.McpServer.Prompts;
using EnterpriseAppAI.McpServer.Resources;
using EnterpriseAppAI.McpServer.Services;
using EnterpriseAppAI.McpServer.Tools;
using ModelContextProtocol.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Register Application layer
builder.Services.AddApplication();

// Register Infrastructure layer
builder.Services.AddInfrastructure(builder.Configuration);

// Register MCP Server

builder.Services
    .AddMcpServer()
    .WithHttpTransport(options =>
    {   
        options.Stateless = true;
    })
    .WithTools<LeaveMcpTools>()
    .WithTools<JiraMcpTools>()
    .WithTools<GitHubMcpTools>()
    .WithResources<HRPolicyResource>()
    .WithResources<EmployeeResource>()
    .WithPrompts<HRAssistantPrompt>();

builder.Services
    .AddOptions<JiraOptions>()
    .Bind(builder.Configuration.GetSection("Jira"))
    .Validate(
        options => !string.IsNullOrWhiteSpace(options.BaseUrl),
        "Jira BaseUrl is required.")
    .Validate(
        options => !string.IsNullOrWhiteSpace(options.ApiToken),
        "Jira ApiToken is required.")
    .ValidateOnStart();

builder.Services.AddHttpClient<JiraService>();

builder.Services
    .AddOptions<GitHubOptions>()
    .Bind(builder.Configuration.GetSection("GitHub"))
    .Validate(
        options => !string.IsNullOrWhiteSpace(options.ApiUrl),
        "GitHub ApiUrl is required.")
    .Validate(
        options => !string.IsNullOrWhiteSpace(options.Token),
        "GitHub Token is required.")
    .ValidateOnStart();

builder.Services.AddHttpClient<GitHubService>();

var app = builder.Build();

// Map MCP endpoint
app.MapMcp("/mcp");

app.Run();