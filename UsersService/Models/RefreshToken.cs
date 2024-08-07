namespace UsersService.Models;

public class RefreshToken : BaseEntity
{
    public string Token { get; set; }
    
    public Guid UserId { get; set; }

    public User User { get; set; }
    
    public DateTimeOffset ExpireAt { get; set; }
}