using MediatR;
using UsersService.CQRS.Queries;
using UsersService.Models;
using UsersService.Repositories;

namespace UsersService.CQRS.Handlers;

public class GetAbilityByIdHandler : IRequestHandler<GetAbilityById, Ability>
{
    private readonly ICRUDRepository<Ability> _repository;

    public GetAbilityByIdHandler(ICRUDRepository<Ability> repository)
    {
        _repository = repository;
    }

    public Task<Ability> Handle(GetAbilityById request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_repository.GetById(request.Id));
    }
}