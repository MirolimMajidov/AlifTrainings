using UsersService.Models;

namespace UsersService.Services;

public interface IUserService
{
    /// <summary>
    /// Get all entities
    /// </summary>
    IEnumerable<User> GetEntities();
    
    /// <summary>
    /// Get entities as paged
    /// </summary>
    /// <param name="page">ID of the page to identify the first element. If it is less than 1, it will be automatically 1.</param>
    /// <param name="pageSize">Number of entities to retrieve. If it is less than 1, it will be automatically 10.</param>
    /// <param name="totalCount">All items</param>
    /// <returns>Returns filtered entities based on pagination request</returns>
    List<User> GetEntitiesAsPagination(int page, int pageSize, out int totalCount);

    /// <summary>
    /// Get entity by ID
    /// </summary>
    /// <param name="id">ID to search by that</param>
    /// <returns>Return an entity if found, otherwise null</returns>
    User GetById(Guid id);

    /// <summary>
    /// To add/store a new entity to the database
    /// </summary>
    /// <param name="entity">Entity to store</param>
    /// <returns>Return added an entity</returns>
    User Add(User entity);

    /// <summary>
    /// To update exists entity
    /// </summary>
    /// <param name="entity">Entity to update</param>
    bool Update(User entity);

    /// <summary>
    /// To delete entity
    /// </summary>
    /// <param name="entity">Entity to delete it form the database</param>
    bool Delete(User entity);

    /// <summary>
    /// To save all changes
    /// </summary>
    bool Save();

    /// <summary>
    /// To save all changes
    /// </summary>
    Task<bool> SaveAsync(CancellationToken cancellationToken);
}