using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserService.Models;

namespace UserService.Infrastructure.Configurations;

public class UserConfiguration: IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("MyUsers");

        builder.HasKey(p => p.Id);
        
        builder.Property(p => p.FirstName).HasMaxLength(20).HasColumnName("Name");
        builder.Property(p => p.LastName).HasMaxLength(20);
        builder.Property(p => p.Email).HasMaxLength(50);
        builder.Property(p => p.Age);
        
        var users = new List<User>()
        {
            new User() { FirstName = "Ali", LastName = "Valiev", Age = 23},
            new User() { FirstName = "James", LastName = "Esh", Age = 87},
        };
        builder.HasData(users);
    }
}