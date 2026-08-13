using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace EnterpriseAppAI.Infrastructure.AI.MCP;

public static class McpClientDependencyInjection
{
    public static IServiceCollection AddMcpClient(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services
            .AddOptions<McpOptions>()
            .Bind(configuration.GetSection(McpOptions.SectionName))
            .Validate(
                options => !string.IsNullOrWhiteSpace(options.ServerUrl),
                "Mcp:ServerUrl is required.")
            .ValidateOnStart();

        services.AddSingleton<IMcpClientService>(sp =>
        {
            var options = sp
                .GetRequiredService<IOptions<McpOptions>>()
                .Value;

            return McpClientService
                .CreateAsync(options.ServerUrl)
                .GetAwaiter()
                .GetResult();
        });

        services.AddScoped<McpKernelPluginFactory>(); 
        services.AddScoped<McpSemanticKernelService>();
        services.AddScoped<McpContextPlugin>();

        return services;
    }
}