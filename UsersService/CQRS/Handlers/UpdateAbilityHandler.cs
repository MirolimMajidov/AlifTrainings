using MediatR;
using UsersService.CQRS.Commands;
using UsersService.Models;
using UsersService.Repositories;

namespace UsersService.CQRS.Handlers;

public class UpdateAbilityHandler : IRequestHandler<UpdateAbility, Ability>
{
    private readonly ICRUDRepository<Ability> _repository;

    public UpdateAbilityHandler(ICRUDRepository<Ability> repository)
    {
        _repository = repository;
    }

    public async Task<Ability> Handle(UpdateAbility request, CancellationToken cancellationToken)
    {
        var _ability = _repository.GetById(request.Id);
        if (_ability is null)
            throw new Exception("Ability not found with the passing id");

        var exists = _repository.GetEntities().Any(a => a.Id != request.Id && a.Name == request.Name);
        if (exists)
            throw new Exception("Ability already created with this name");

        _ability.Name = request.Name;
        _repository.Update(_ability);
        await _repository.SaveAsync(cancellationToken);
        return _ability;
    }
}