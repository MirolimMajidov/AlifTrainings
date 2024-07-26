using System.Collections.Concurrent;
using Microsoft.AspNetCore.Mvc;
using UserService.DTOs;
using UserService.Models;

namespace UserService.Controllers;

[ApiController]
[Route("[controller]")]
//[Route("api/[controller]/[action]")]
public class UsersController : ControllerBase
{
    private static ConcurrentDictionary<Guid, User> Users;

    public UsersController()
    {
        Users ??= CreateUsers(2);
    }

    ConcurrentDictionary<Guid, User> CreateUsers(int usersCount)
    {
        var users = new ConcurrentDictionary<Guid, User>();
        for (int i = 1; i <= usersCount; i++)
        {
            var id = Guid.NewGuid();
            users.TryAdd(id, new User
            {
                Id = id,
                FirstName = "FirstName" + i,
                LastName = "LastName" + i
            });
        }

        return users;
    }

    [HttpGet]
    public IEnumerable<User> GetUsers()
    {
        return Users.Values;
    }
    
    [HttpGet("{id:guid}")]
    public User GetById(Guid id)
    {
        if(Users.TryGetValue(id, out User user))
            return user;

        return default;
    }

    [HttpPost]
    public IActionResult Create(CreateUserDTO user)
    {
        var _user = new User
        {
            Id = Guid.NewGuid(),
            FirstName = user.FirstName,
            LastName = user.LastName,
            Age = user.Age
        };
        Users.TryAdd(_user.Id, _user);
        
        return Ok(_user);
    }

    [HttpPut("{id:guid}")]
    public IActionResult Update(Guid id, UpdateUserDTO user)
    {
        if (Users.TryGetValue(id, out User _user))
        {
            _user.FirstName = user.FirstName;
            _user.LastName = user.LastName;
            _user.Age = user.Age;

            return Ok();
        }
        else
        {
           return NotFound();
        }
    }

    [HttpDelete("{id:guid}")]
    public IActionResult Delete(Guid id)
    {
        if (Users.ContainsKey(id))
        {
            Users.TryRemove(id, out User value);
            return Ok();
        }
        else
           return NotFound();
    }
}