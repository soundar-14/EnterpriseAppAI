using EnterpriseAppAI.Application.AI.Interfaces;
using EnterpriseAppAI.Application.Interfaces.Identity;
using EnterpriseAppAI.Application.Interfaces.Persistence;
using EnterpriseAppAI.Infrastructure.AI.Abstractions;
using EnterpriseAppAI.Infrastructure.AI.MCP;
using EnterpriseAppAI.Infrastructure.AI.Options;
using EnterpriseAppAI.Infrastructure.AI.Plugins;
using EnterpriseAppAI.Infrastructure.AI.RAG.Interfaces;
using EnterpriseAppAI.Infrastructure.AI.RAG.Services;
using EnterpriseAppAI.Infrastructure.AI.Services;
using EnterpriseAppAI.Infrastructure.Identity;
using EnterpriseAppAI.Infrastructure.Persistence;
using EnterpriseAppAI.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;

namespace EnterpriseAppAI.Infrastructure.DependencyInjection;

/// <summary>
/// Registers Infrastructure layer services. The API project only calls
/// <see cref="AddInfrastructure"/> and knows nothing about ApplicationDbContext directly.
/// </summary>
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));

        var azureOpenAISection = configuration.GetSection(AzureOpenAIOptions.SectionName);

        // Bind configuration to strongly typed options
        var azureOpenAIOptions = azureOpenAISection.Get<AzureOpenAIOptions>()
            ?? throw new InvalidOperationException(
                $"Configuration section '{AzureOpenAIOptions.SectionName}' is missing.");

        // Register Options Pattern
        services
            .AddOptions<AzureOpenAIOptions>()
            .Bind(azureOpenAISection)
            .ValidateDataAnnotations()
            .ValidateOnStart();

        // Register Semantic Kernel
        services
            .AddKernel()
            .AddAzureOpenAIChatCompletion(
                deploymentName: azureOpenAIOptions.ChatDeploymentName,
                endpoint: azureOpenAIOptions.Endpoint,
                apiKey: azureOpenAIOptions.ApiKey)
            .AddAzureOpenAITextEmbeddingGeneration(
                deploymentName: azureOpenAIOptions.EmbeddingDeploymentName,
                endpoint: azureOpenAIOptions.Endpoint,
                apiKey: azureOpenAIOptions.ApiKey);
        ;


        var searchSection = configuration.GetSection(AzureAISearchOptions.SectionName);

        services
            .AddOptions<AzureAISearchOptions>()
            .Bind(searchSection)
            .ValidateDataAnnotations()
            .ValidateOnStart();




        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddScoped<IAIPlugin, EmployeePlugin>();

        services.AddScoped<DepartmentPlugin>();
        services.AddScoped<IAIPlugin, DepartmentPlugin>();

        services.AddScoped<LeavePlugin>();
        services.AddScoped<IAIPlugin, LeavePlugin>();

        services.AddScoped<HRPlugin>();
        services.AddScoped<IAIPlugin, HRPlugin>();

        services.AddScoped<ITSupportPlugin>();
        services.AddScoped<IAIPlugin, ITSupportPlugin>();

        services.AddScoped<IPdfReaderService, PdfReaderService>();
        services.AddScoped<ITextChunkingService, TextChunkingService>();
        services.AddScoped<IEmbeddingService, EmbeddingService>();

        services.AddScoped<IAzureAISearchService, AzureAISearchService>();

        services.AddScoped<HRAssistantPromptService>();

        services.AddScoped<IRagService, RagService>();

        return services;
    }
}
