using Microsoft.EntityFrameworkCore;
using UsersService.Infrastructure;
using UsersService.Models;

namespace UsersService.Repositories;

public class MemoryRepository<TEntity> : IMemoryRepository<TEntity> where TEntity: BaseEntity
{
    private static readonly Dictionary<Guid, TEntity> Entities = new();

    public MemoryRepository()
    {
    }

    public IEnumerable<TEntity> GetEntities()
    {
        return Entities.Values;
    }

    public TEntity GetById(Guid id)
    {
        if (Entities.TryGetValue(id, out var item))
            return item;
        
        return default;
    }

    public TEntity Add(TEntity entity)
    {
        Entities.Add(entity.Id, entity);

        return entity;
    }

    public bool Update(TEntity entity)
    {
        Entities[entity.Id] = entity;

        return true;
    }

    public bool Delete(Guid id)
    {
        Entities.Remove(id);

        return true;
    }

    public bool Delete(TEntity entity)
    {
        Entities.Remove(entity.Id);
        
        return true;
    }

    public bool Save()
    {
        return true;
    }

    public Task<bool> SaveAsync(CancellationToken cancellationToken = default)
    {
        return Task.FromResult(true);
    }
}