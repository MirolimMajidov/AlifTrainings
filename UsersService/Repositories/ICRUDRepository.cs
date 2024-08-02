using UsersService.Models;

namespace UsersService.Repositories;

public interface ICRUDRepository<TEntity> where TEntity : BaseEntity
{
    /// <summary>
    /// Get all entities
    /// </summary>
    IEnumerable<TEntity> GetEntities();
    
    /// <summary>
    /// Get entity by ID
    /// </summary>
    /// <param name="id">ID to search by that</param>
    /// <returns>Return an entity if found, otherwise null</returns>
    TEntity GetById(Guid id);

    /// <summary>
    /// To add/store a new entity to the database
    /// </summary>
    /// <param name="entity">Entity to store</param>
    /// <returns>Return added an entity</returns>
    TEntity Add(TEntity entity);

    /// <summary>
    /// To update exists entity
    /// </summary>
    /// <param name="entity">Entity to update</param>
    bool Update(TEntity entity);

    /// <summary>
    /// To delete entity
    /// </summary>
    /// <param name="id">ID to find the entity by this and delete it from the database if found</param>
    bool Delete(Guid id);

    /// <summary>
    /// To delete entity
    /// </summary>
    /// <param name="entity">Entity to delete it form the database</param>
    bool Delete(TEntity entity);
    
    /// <summary>
    /// To save all changes
    /// </summary>
    bool Save();
    
    /// <summary>
    /// To save all changes
    /// </summary>
    Task<bool> SaveAsync(CancellationToken cancellationToken);
}