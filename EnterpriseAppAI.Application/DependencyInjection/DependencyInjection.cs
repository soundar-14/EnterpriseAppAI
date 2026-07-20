using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace EnterpriseAppAI.Application.DependencyInjection;

/// <summary>
/// Registers Application layer services (MediatR). The API only calls
/// <see cref="AddApplication"/> and knows nothing about MediatR configuration internally.
/// </summary>
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));

        return services;
    }
}
