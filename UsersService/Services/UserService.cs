using UsersService.Models;
using UsersService.Repositories;

namespace UsersService.Services;

public class UserService : IUserService
{
    protected readonly ICRUDRepository<User> _repository;

    public UserService(ICRUDRepository<User> repository)
    {
        _repository = repository;
    }

    public IEnumerable<User> GetEntities()
    {
        return _repository.GetEntities();
    }

    public List<User> GetEntitiesAsPagination(int page, int pageSize, out int totalCount)
    {
        var entitiesAsQuery = _repository.GetEntities().AsQueryable();
        totalCount = entitiesAsQuery.Count();
        if (totalCount > 0)
        {
            if (page < 1)
                page = 1;

            if (pageSize < 1)
                page = 10;

            return entitiesAsQuery
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }
        
        return [];
    }

    public User GetById(Guid id)
    {
        return _repository.GetById(id);
    }

    public User Add(User entity)
    {
        if (string.IsNullOrEmpty(entity.FirstName))
            throw new ArgumentException("FirstName cannot be empty");
        
        return _repository.Add(entity);
    }

    public bool Update(User entity)
    {
        return _repository.Update(entity);
    }

    public bool Delete(User entity)
    {
        return _repository.Delete(entity);
    }

    public bool Save()
    {
        return _repository.Save();
    }

    public async Task<bool> SaveAsync(CancellationToken cancellationToken)
    {
        return await _repository.SaveAsync(cancellationToken);
    }
}