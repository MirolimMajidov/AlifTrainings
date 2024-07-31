using System.Collections.Concurrent;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql.Internal;
using UserService.DTOs;
using UserService.Infrastructure;
using UserService.Models;

namespace UserService.Controllers;

[ApiController]
[Route("[controller]")]
//[Route("api/[controller]/[action]")]
public class UserController : ControllerBase
{
    private UserContext _context;
    private readonly ILogger<UserController> _logger;

    public UserController(UserContext context, ILogger<UserController> logger)
    {
        _context = context;
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<User> GetUsers()
    {
        _logger.LogInformation("Started my API");
        //var users1 = _context.Users.Include(u=>u.UserRoles).ThenInclude(ur=>ur.Role).ToList();
        // var roles = _context.Users
        //     .Include(u=>u.UserRoles)
        //     .ThenInclude(ur=>ur.Role)
        //     .SelectMany(u=>u.UserRoles)
        //     .Select(ur=>ur.Role).Distinct();
        // var sqlQuery = roles.ToQueryString();
        
        var users = _context.Users.ToList();
        var user = users.First(u=>u.Id== Guid.Parse("1a4374e4-2da7-4617-ac6d-a58f40877b1b"));
        var userRoles = user.UserRoles;
        var role = userRoles.First().Role;
        _logger.LogInformation("Finished my API. User id is {id}", user.Id);

        //var text = string.Format("Hi, my name is {name}, and age is {age}", "Mirolim", "29");
        
        return users;
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        var users = _context.Users.Where(u => true).AsQueryable();
        var user = users.SingleOrDefault(u => u.Id == id);
        if (user is null)
            return NotFound();

        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateUserDTO user)
    {
        var _user = new User
        {
            Id = Guid.NewGuid(),
            FirstName = user.FirstName,
            LastName = user.LastName,
            Age = user.Age
        };
        _context.Users.Add(_user);

        await _context.SaveChangesAsync();

        return Ok(_user);
    }

    [HttpPut("{id:guid}")]
    public IActionResult Update(Guid id, UpdateUserDTO user)
    {
        var _user = _context.Users.SingleOrDefault(u => u.Id == id);
        if (_user is null)
            return NotFound();

        _user.FirstName = user.FirstName;
        _user.LastName = user.LastName;
        _user.Age = user.Age;
        _context.Users.Update(_user);
        _context.SaveChanges();

        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public IActionResult Delete(Guid id)
    {
        var user = _context.Users.SingleOrDefault(u => u.Id == id);
        if (user is null)
            return NotFound();

        _context.Users.Remove(user);
        _context.SaveChanges();

        return Ok();
    }
}