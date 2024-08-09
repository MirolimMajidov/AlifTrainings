using MediatR;
using Microsoft.EntityFrameworkCore;
using UsersService.CQRS.Queries;
using UsersService.Models;
using UsersService.Repositories;

namespace UsersService.CQRS.Handlers;

public class GetAllAbilitiesHandler : IRequestHandler<GetAllAbilities, List<Ability>>
{
    private readonly ICRUDRepository<Ability> _repository;

    public GetAllAbilitiesHandler(ICRUDRepository<Ability> repository)
    {
        _repository = repository;
    }

    public async Task<List<Ability>> Handle(GetAllAbilities request, CancellationToken cancellationToken)
    {
        return await _repository.GetEntities().AsQueryable().ToListAsync(cancellationToken);
    }
}