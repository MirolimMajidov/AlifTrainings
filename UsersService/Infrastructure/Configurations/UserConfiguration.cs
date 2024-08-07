using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UsersService.Models;

namespace UsersService.Infrastructure.Configurations;

public class UserConfiguration: IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(p => p.Id);
        
        builder.Property(p => p.FirstName).HasMaxLength(20).HasColumnName("Name");
        builder.Property(p => p.LastName).HasMaxLength(20);
        builder.Property(p => p.Email).HasMaxLength(50);
        builder.Property(p => p.Age);
        
        builder.Property(p => p.UserName).IsRequired();
        builder.HasIndex(p => p.UserName)
            .IsUnique();
        
        // builder.HasMany(p => p.UserRoles)
        //     .WithOne(u => u.User)
        //     .HasForeignKey(r => r.UserId)
        //     .OnDelete(DeleteBehavior.Cascade);

    }
}