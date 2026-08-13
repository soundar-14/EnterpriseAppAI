using EnterpriseAppAI.Application.DependencyInjection;
using EnterpriseAppAI.Infrastructure.DependencyInjection;
using EnterpriseAppAI.McpServer.Prompts;
using EnterpriseAppAI.McpServer.Resources;
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
    .WithResources<HRPolicyResource>()
    .WithResources<EmployeeResource>()
    .WithPrompts<HRAssistantPrompt>();  

var app = builder.Build();

// Map MCP endpoint
app.MapMcp("/mcp");

app.Run();