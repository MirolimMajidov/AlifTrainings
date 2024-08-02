using Microsoft.EntityFrameworkCore;
using UsersService.Infrastructure;
using UsersService.Models;

namespace UsersService.Repositories;

public class CRUDRepository<TEntity> : ICRUDRepository<TEntity> where TEntity: BaseEntity
{
    private readonly UserContext _context;

    public CRUDRepository(UserContext context)
    {
        _context = context;
    }

    public IEnumerable<TEntity> GetEntities()
    {
        return _context.Set<TEntity>();
    }

    public TEntity GetById(Guid id)
    {
        return _context.Find(typeof(TEntity), id) as TEntity;
    }

    public TEntity Add(TEntity entity)
    {
        _context.Add(entity);

        return entity;
    }

    public bool Update(TEntity entity)
    {
        _context.Update(entity);

        return true;
    }

    public bool Delete(Guid id)
    {
        var entity = GetById(id);
        if (entity is null) return false;

        return Delete(entity);
    }

    public bool Delete(TEntity entity)
    {
        _context.Remove(entity);
        
        return true;
    }

    public bool Save()
    {
        var result = _context.SaveChanges();
        return result > 0;
    }

    public async Task<bool> SaveAsync(CancellationToken cancellationToken = default)
    {
        var result = await _context.SaveChangesAsync(cancellationToken);
        return result > 0;
    }
}