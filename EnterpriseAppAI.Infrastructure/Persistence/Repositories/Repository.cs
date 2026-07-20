using System.Linq.Expressions;
using EnterpriseAppAI.Application.Interfaces.Persistence;
using EnterpriseAppAI.Domain.Common;
using EnterpriseAppAI.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseAppAI.Infrastructure.Persistence.Repositories;

/// <summary>
/// Generic EF Core repository implementation. Works for any entity derived from
/// <see cref="BaseEntity"/> using <see cref="ApplicationDbContext"/> internally.
/// Add/Update/Delete only stage changes; <see cref="DbContext.SaveChangesAsync(CancellationToken)"/>
/// is invoked by the Unit of Work, not here.
/// </summary>
public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<TEntity> _dbSet;

    public Repository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    public async Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbSet.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbSet.ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await _dbSet.Where(predicate).ToListAsync(cancellationToken);
    }

    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await _dbSet.AddAsync(entity, cancellationToken);
    }

    public void Update(TEntity entity)
    {
        _dbSet.Update(entity);
    }

    public void Delete(TEntity entity)
    {
        _dbSet.Remove(entity);
    }

    public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await _dbSet.AnyAsync(predicate, cancellationToken);
    }
}
