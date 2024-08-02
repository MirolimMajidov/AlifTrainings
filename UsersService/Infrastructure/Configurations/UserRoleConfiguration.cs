using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserService.Models;

namespace UserService.Infrastructure.Configurations;

public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.ToTable(nameof(UserContext.UserRoles));

        builder.HasKey(p => p.Id);

        builder.HasIndex(p=> new { p.UserId, p.RoleId}).IsUnique();

        builder.HasOne(p => p.User)
            .WithMany(u => u.UserRoles)
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(p => p.Role)
            .WithMany()
            .HasForeignKey(r => r.RoleId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}