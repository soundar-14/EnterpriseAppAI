using EnterpriseAppAI.Application.AI.Interfaces;
using EnterpriseAppAI.Infrastructure.AI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EnterpriseAppAI.Infrastructure.AI.DependencyInjection;

public static class AiDependencyInjection
{
    public static IServiceCollection AddAI(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<IChatService, ChatService>();

        return services;
    }
}