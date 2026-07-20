using EnterpriseAppAI.Domain.Common;

namespace EnterpriseAppAI.Application.Interfaces.Persistence;

/// <summary>
/// Coordinates repositories against a single database transaction/context instance
/// and commits all staged changes together via <see cref="SaveChangesAsync"/>.
/// </summary>
public interface IUnitOfWork
{
    /// <summary>
    /// Returns a generic repository for the given entity type, sharing this
    /// Unit of Work's underlying DbContext instance.
    /// </summary>
    IRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
