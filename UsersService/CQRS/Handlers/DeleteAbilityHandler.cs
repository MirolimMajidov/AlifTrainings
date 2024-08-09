using MediatR;
using UsersService.CQRS.Commands;
using UsersService.Models;
using UsersService.Repositories;

namespace UsersService.CQRS.Handlers;

public class DeleteAbilityHandler : IRequestHandler<DeleteAbility, Ability>
{
    private readonly ICRUDRepository<Ability> _repository;

    public DeleteAbilityHandler(ICRUDRepository<Ability> repository)
    {
        _repository = repository;
    }

    public async Task<Ability> Handle(DeleteAbility request, CancellationToken cancellationToken)
    {
        var _ability = _repository.GetById(request.Id);
        if (_ability is null)
            throw new Exception("Ability not found with the passing id");

        _repository.Delete(_ability);
        await _repository.SaveAsync(cancellationToken);
        return _ability;
    }
}