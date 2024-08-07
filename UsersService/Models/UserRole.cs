using Microsoft.EntityFrameworkCore.Infrastructure;

namespace UsersService.Models;

public class UserRole : BaseEntity
{
    private ILazyLoader _lazyLoader;

    public UserRole() : base()
    {
    }

    public UserRole(ILazyLoader lazyLoader)
    {
        Id = Guid.NewGuid();
        _lazyLoader = lazyLoader;
    }
    
    public Guid UserId { get; set; }
    public virtual User User { get; set; }
    public Guid RoleId { get; set; }
    
    public Role _role;
    public virtual Role Role
    {
        get
        {
            if (_role is null)
                _lazyLoader.Load(this, nameof(Role));

            return _role;
        }
        set { _role = value; }
    }
}