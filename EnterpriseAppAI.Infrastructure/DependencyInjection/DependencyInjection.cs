using EnterpriseAppAI.Application.Interfaces.Persistence;
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

        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
