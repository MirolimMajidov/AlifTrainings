using MediatR;
using Microsoft.AspNetCore.Mvc;
using UsersService.Models;

namespace UsersService.CQRS.Queries;

public class GetAbilityById : IRequest<Ability>
{
    [FromQuery] public Guid Id { get; set; }
}