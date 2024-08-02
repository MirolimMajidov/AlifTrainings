namespace UsersService.Services;

public class IdProvider
{
    public IdProvider()
    {
        Id = Guid.NewGuid();
    }
    
    public Guid Id { get; }
}