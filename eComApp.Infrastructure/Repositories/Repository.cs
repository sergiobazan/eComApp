using eComApp.Application.Exceptions;
using eComApp.Domain.Abstract.Generic;
using Microsoft.EntityFrameworkCore;

namespace eComApp.Infrastructure.Repositories;

public class Repository<TEntity>(ApplicationDbContext context) : IGenericRepository<TEntity> where TEntity : class
{
    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await context.Set<TEntity>().AsNoTracking().ToListAsync();
    }

    public async Task<TEntity?> GetByIdAsync(Guid id)
    {
        return await context.Set<TEntity>().FindAsync(id);
    }

    public void Add(TEntity entity)
    {
        context.Set<TEntity>().Add(entity);
    }

    public void UpdateAsync(TEntity entity)
    {
        context.Set<TEntity>().Update(entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await context.Set<TEntity>().FindAsync(id);

        if (entity is null) throw new ItemNotFoundException("Item with given Id not found");

        context.Set<TEntity>().Remove(entity);
    }
}
