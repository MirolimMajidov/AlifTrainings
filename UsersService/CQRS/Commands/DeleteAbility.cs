using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UsersService.Models;

namespace UsersService.CQRS.Commands;

public class DeleteAbility : IRequest<Ability>
{
    [FromQuery]
    public Guid Id { get; set; }
}