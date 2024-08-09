using System.ComponentModel.DataAnnotations;
using MediatR;
using UsersService.Models;

namespace UsersService.CQRS.Commands;

public class UpdateAbility : IRequest<Ability>
{
    [Required]
    public Guid Id { get; set; }
    
    [Required]
    public string Name { get; set; }
}