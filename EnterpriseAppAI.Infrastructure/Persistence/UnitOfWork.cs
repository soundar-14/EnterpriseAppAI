using System.Collections.Concurrent;
using EnterpriseAppAI.Application.Interfaces.Persistence;
using EnterpriseAppAI.Domain.Common;
using EnterpriseAppAI.Infrastructure.Persistence.Repositories;

namespace EnterpriseAppAI.Infrastructure.Persistence;

/// <summary>
/// EF Core Unit of Work. Caches one <see cref="Repository{TEntity}"/> per entity type per
/// request/scope and commits all staged changes through the shared <see cref="ApplicationDbContext"/>.
/// </summary>
public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    private readonly ConcurrentDictionary<Type, object> _repositories = new();

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    public IRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
    {
        return (IRepository<TEntity>)_repositories.GetOrAdd(
            typeof(TEntity),
            _ => new Repository<TEntity>(_context));
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }
}
