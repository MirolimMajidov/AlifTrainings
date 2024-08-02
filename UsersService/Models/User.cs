using Microsoft.EntityFrameworkCore.Infrastructure;

namespace UserService.Models;

public class User
{
    private ILazyLoader _lazyLoader;

    public User()
    {
        Id = Guid.NewGuid();
    }
    
    public User(ILazyLoader lazyLoader)
    {
        Id = Guid.NewGuid();
        _lazyLoader = lazyLoader;
    }

    public Guid Id { get; set; }

    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string Email { get; set; }
    
    public int Age { get; set; }

    private List<UserRole> _userRoles = null;
    public virtual List<UserRole> UserRoles
    {
        get
        {
            if(_userRoles is null)
                _lazyLoader.Load(this, nameof(UserRoles));

            return _userRoles;
        }
        set
        {
            _userRoles = value;
        }
    }
}