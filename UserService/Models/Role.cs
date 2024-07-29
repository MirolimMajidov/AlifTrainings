namespace UserService.Models;

public class Role
{
    public Role()
    {
        Id = Guid.NewGuid();
    }
    
    public Guid Id { get; set; }

    public string Name { get; set; }
}