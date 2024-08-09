using MediatR;
using UsersService.CQRS.Commands;
using UsersService.Models;
using UsersService.Repositories;

namespace UsersService.CQRS.Handlers;

public class CreateAbilityHandler : IRequestHandler<CreateAbility, (Ability, string)>
{
    private readonly ICRUDRepository<Ability> _repository;

    public CreateAbilityHandler(ICRUDRepository<Ability> repository)
    {
        _repository = repository;
    }

    public async Task<(Ability, string)> Handle(CreateAbility request, CancellationToken cancellationToken)
    {
        try
        {
            var exists = _repository.GetEntities().Any(a => a.Name == request.Name);
            if (exists)
                return (null, "Ability already created with this name");

            var _ability = new Ability()
            {
                Id = Guid.NewGuid(),
                Name = request.Name
            };
            _repository.Add(_ability);

            await _repository.SaveAsync(cancellationToken);

            return (_ability, string.Empty);
        }
        catch (Exception ex)
        {
            return (null, ex.Message);
        }
    }
}