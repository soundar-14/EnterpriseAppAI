using System.Linq.Expressions;
using EnterpriseAppAI.Domain.Common;

namespace EnterpriseAppAI.Application.Interfaces.Persistence;

/// <summary>
/// Generic repository contract for CRUD access to entities derived from <see cref="BaseEntity"/>.
/// Deliberately does not expose <see cref="IQueryable{T}"/> to keep persistence concerns out of
/// the Application/Domain layers - all querying is expressed through explicit methods.
/// </summary>
public interface IRepository<TEntity> where TEntity : BaseEntity
{
    Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<IReadOnlyList<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);

    Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);

    void Update(TEntity entity);

    void Delete(TEntity entity);

    Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
}
