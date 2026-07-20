using EnterpriseAppAI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseAppAI.Infrastructure.Persistence;

/// <summary>
/// EF Core persistence context for the application. Entity configurations are
/// applied automatically from Fluent API configuration classes in this assembly.
/// </summary>
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Employee> Employees => Set<Employee>();

    public DbSet<Department> Departments => Set<Department>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
