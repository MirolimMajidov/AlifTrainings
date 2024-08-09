using MediatR;
using Microsoft.AspNetCore.Mvc;
using UsersService.CQRS.Commands;
using UsersService.CQRS.Queries;
using UsersService.Models;
using UsersService.Repositories;
using UsersService.Services;

namespace UsersService.Controllers;

[ApiController]
[Route("[controller]")]
//[Route("api/[controller]/[action]")]
public class AbilityController : ControllerBase
{
    private readonly IMediator _mediator;
    private ICRUDRepository<Ability> _service;
    private ILogger<AbilityController> _logger;
    private readonly IdProvider _provider;

    public AbilityController(IMediator mediator, ICRUDRepository<Ability> service, ILogger<AbilityController> logger)
    {
        _mediator = mediator;
        _service = service;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IEnumerable<Ability>> GetAbilities()
    {
        _logger.LogInformation("Text");
        var getAllAbilities = new GetAllAbilities();
        return await _mediator.Send(getAllAbilities);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var ability = await _mediator.Send(new GetAbilityById() { Id = id });
        if (ability is null)
            return NotFound();

        return Ok(ability);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateAbility abilityDto, CancellationToken cancellationToken)
    {
        var created = await _mediator.Send(abilityDto);
        if (created.Item1 is null)
            return BadRequest(created.Item2);

        return Ok(created.Item1);
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateAbility abilityDto)
    {
        try
        {
            var updatedAbility = await _mediator.Send(abilityDto);

            return Ok(updatedAbility);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(DeleteAbility deleteAbility)
    {
        try
        {
            var deletedAbility = await _mediator.Send(deleteAbility);

            return Ok(deletedAbility);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}