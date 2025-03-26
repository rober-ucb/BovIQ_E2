using BovIQ.Domain.Repositories;
using BovIQ.Persistence.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace BovIQ.Persistence.Repositories;

public abstract class BaseRepository<TEntity, TKey>(IApplicationDbContext context) : IBaseRepository<TEntity, TKey>
    where TEntity : class, new()
    where TKey : struct
{
    protected IApplicationDbContext Context = context;
    public virtual async Task<TEntity> AddAsync(TEntity entity)
    {
        await Context.Set<TEntity>().AddAsync(entity);
        return entity;
    }

    public virtual void DeleteAsync(TEntity entity) 
        => Context.Set<TEntity>().Remove(entity);

    public virtual async Task<TEntity?> FindByIdAsync(TKey id) 
        => await Context.Set<TEntity>().FindAsync(id);

    public virtual Task<List<TEntity>> GetAllAsync() 
        => Context.Set<TEntity>()
            .AsNoTracking()
            .ToListAsync();

    public virtual void Update(TEntity entity) 
        => Context.Set<TEntity>().Update(entity);
}
