using Microsoft.EntityFrameworkCore;
using UsersService.Infrastructure.Configurations;
using UsersService.Models;

namespace UsersService.Infrastructure;

public class UserContext : DbContext
{
    public DbSet<User> Users { get; set; }
    
    public DbSet<Role> Roles { get; set; }

    // public UserContext() : base()
    // {
    // }

    public UserContext(DbContextOptions options) : base(options)
    {
    }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     if (!optionsBuilder.IsConfigured)
    //         optionsBuilder.UseInMemoryDatabase("MyDB");
    //     //base.OnConfiguring(optionsBuilder);
    // }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.Entity<User>().ToTable(nameof(Users));
        // base.OnModelCreating(modelBuilder);
        
        //modelBuilder.ApplyConfiguration(new UserConfiguration());
        
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(Program).Assembly);
    }
}