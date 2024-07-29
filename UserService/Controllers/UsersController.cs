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
public class UsersController : ControllerBase
{
    private UserContext _context;

    public UsersController(UserContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IEnumerable<User> GetUsers()
    {
        return _context.Users.ToList();
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