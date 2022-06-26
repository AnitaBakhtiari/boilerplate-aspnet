using Microsoft.EntityFrameworkCore;

namespace DataCore.Data.Repository;

public class CoreRepository<TEntity,TContext> : ICoreRepository<TEntity> where TEntity : class where TContext : DbContext
{
    protected readonly TContext _context;

    public CoreRepository(TContext context)
    {
        _context = context;
    }
    public TEntity Add(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
        return entity;
    }

    public async Task<TEntity> GetAsync(long id)
    {
        return await _context.Set<TEntity>().FindAsync(id);
    }

    public async Task<TEntity> DeleteAsync(long id)
    {
        var entity = await GetAsync(id);
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        _context.Set<TEntity>().Remove(entity);
        return entity;
    }
    
    public IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities)
    {
        _context.Set<TEntity>().AddRange(entities);
        return entities;
    }
    public TEntity Delete(TEntity entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        _context.Set<TEntity>().Remove(entity);
        return entity;
    }
    public TEntity Update(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        return entity;
    }
    public IEnumerable<TEntity> UpdateRange(IEnumerable<TEntity> entities)
    {
        foreach (var entity in entities)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        return entities;
    }
    public async Task<IEnumerable<TEntity>> GetListAsync()
    {
        return await _context.Set<TEntity>().ToListAsync();
    }
    public Task<long> CountAsync => _context.Set<TEntity>().LongCountAsync();
    public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
}