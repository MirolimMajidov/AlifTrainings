using System.ComponentModel.DataAnnotations;
using MediatR;
using UsersService.Models;

namespace UsersService.CQRS.Commands;

public class CreateAbility : IRequest<(Ability, string)>
{
    [Required]
    public string Name { get; set; }
}