using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UsersService.DTOs;
using UsersService.Models;
using UsersService.Services;

namespace UsersService.Controllers;

[ApiController]
[Route("[controller]")]
//[Route("api/[controller]/[action]")]
// [Authorize]
public class UserController : ControllerBase
{
    private IUserService _service;
    private ILogger<UserController> _logger;
    private readonly IdProvider _provider;

    public UserController(IUserService service, ILogger<UserController> logger, IdProvider provider)
    {
        _service = service;
        _logger = logger;
        _provider = provider;
    }
    
    [HttpGet("IdProvider")]
    public Guid[] GetId([FromServices]IdProvider provider2, [FromServices]IdProvider provider3)
    {
        return [_provider.Id, provider2.Id, provider3.Id];
    }

    [AllowAnonymous]
    [HttpGet]
    public IEnumerable<User> GetUsers()
    {
        _logger.LogInformation("Text");
        return _service.GetEntities().ToList();
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        //var logger = HttpContext.RequestServices.GetService<ILogger<UserController>>();
        var user = _service.GetById(id);
        if (user is null)
            return NotFound();

        return Ok(user);
    }

    [HttpPost]
    // [Authorize(Roles = "Admin, Dev")]
    public async Task<IActionResult> Create(CreateUserDTO user, CancellationToken cancellationToken)
    {
        var _user = new User
        {
            Id = Guid.NewGuid(),
            FirstName = user.FirstName,
            LastName = user.LastName,
            Age = user.Age
        };
        _service.Add(_user);

        await _service.SaveAsync(cancellationToken);

        return Ok(_user);
    }

    // [Authorize(Policy = "myAdmins")]
    //[Authorize(Roles = "Admin, Dev")]
    [HttpPut("{id:guid}")]
    public IActionResult Update(Guid id, UpdateUserDTO user)
    {
        var _user = _service.GetById(id);
        if (_user is null)
            return NotFound();

        _user.FirstName = user.FirstName;
        _user.LastName = user.LastName;
        _user.Age = user.Age;
        _service.Update(_user); 
        _service.Save();

        return Ok();
    }

    // [Authorize(Policy = "myAdmins")]
    [HttpDelete("{id:guid}")]
    public IActionResult Delete(Guid id)
    {
        var user = _service.GetById(id);
        if (user is null)
            return NotFound();

        _service.Delete(user);
        _service.Save();

        return Ok();
    }
}