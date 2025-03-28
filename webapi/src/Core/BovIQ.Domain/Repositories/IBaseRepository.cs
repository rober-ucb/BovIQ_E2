﻿namespace BovIQ.Domain.Repositories;

public interface IBaseRepository<TEntity, TKey> 
    where TEntity : class, new()
    where TKey : struct
{
    Task<TEntity?> FindByIdAsync(TKey id);
    Task<TEntity> InsertAsync(TEntity entity);
    Task<List<TEntity>> GetAllAsync();
    void Update(TEntity entity);
    void Delete(TEntity id);
}
