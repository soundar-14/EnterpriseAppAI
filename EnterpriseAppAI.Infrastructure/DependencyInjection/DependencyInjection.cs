using EnterpriseAppAI.Application.AI.Interfaces;
using EnterpriseAppAI.Application.Interfaces.Identity;
using EnterpriseAppAI.Application.Interfaces.Persistence;
using EnterpriseAppAI.Infrastructure.AI.Services;
using EnterpriseAppAI.Infrastructure.Identity;
using EnterpriseAppAI.Infrastructure.Persistence;
using EnterpriseAppAI.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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

        // Azure OpenAI options: bind configuration and validate on start (manual bind + DataAnnotations validation)
        var azureSection = configuration.GetSection(EnterpriseAppAI.Infrastructure.AI.Options.AzureOpenAIOptions.SectionName);
        var azureOptions = azureSection.Get<EnterpriseAppAI.Infrastructure.AI.Options.AzureOpenAIOptions>();
        if (azureOptions == null)
        {
            throw new InvalidOperationException($"Configuration section '{EnterpriseAppAI.Infrastructure.AI.Options.AzureOpenAIOptions.SectionName}' is missing.");
        }

        // Validate DataAnnotations (if any are present on the options class)
        var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(azureOptions);
        var validationResults = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
        if (!System.ComponentModel.DataAnnotations.Validator.TryValidateObject(azureOptions, validationContext, validationResults, validateAllProperties: true))
        {
            var errors = string.Join("; ", validationResults.Select(r => r.ErrorMessage));
            throw new InvalidOperationException($"AzureOpenAIOptions validation failed: {errors}");
        }

        // Register the validated options instance as singleton
        services.AddSingleton(azureOptions);

        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddScoped<IChatService, ChatService>();

        return services;
    }
}
