using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace UsersService.Models;

public class User : BaseEntity
{
    private ILazyLoader _lazyLoader;

    public User() : base()
    {
    }

    public User(ILazyLoader lazyLoader)
    {
        Id = Guid.NewGuid();
        _lazyLoader = lazyLoader;
    }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string UserName { get; set; }

    [JsonIgnore]
    public string Password { get; set; }

    public string Email { get; set; }

    public int Age { get; set; }

    private List<UserRole> _userRoles = null;

    public virtual List<UserRole> UserRoles
    {
        get
        {
            if (_userRoles is null)
            {
                if (_lazyLoader is null)
                    return [];
                
                _lazyLoader?.Load(this, nameof(UserRoles));
            }

            return _userRoles;
        }
        set { _userRoles = value; }
    }

    public List<RefreshToken> RefreshTokens { get; set; } = new();
}