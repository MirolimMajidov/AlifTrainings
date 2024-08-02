using Microsoft.EntityFrameworkCore;
using UsersService.Infrastructure;
using UsersService.Models;

namespace UsersService.Repositories;

public interface IMemoryRepository<TEntity> : ICRUDRepository<TEntity> where TEntity: BaseEntity
{
    
}