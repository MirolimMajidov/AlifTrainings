using MediatR;
using UsersService.Models;

namespace UsersService.CQRS.Queries;

public class GetAllAbilities : IRequest<List<Ability>>
{
}