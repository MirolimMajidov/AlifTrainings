using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using UsersService.Infrastructure;
using UsersService.Middlewares;
using UsersService.Models;
using ILogger = Serilog.ILogger;

var builder = WebApplication.CreateBuilder(args);

ILogger logger= new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console(LogEventLevel.Warning)
    .WriteTo.File("log.txt",
        outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
    .CreateLogger();

builder.Host.UseSerilog(logger);

var connectionString = builder.Configuration.GetSection("ConnectionString").Value;
builder.Services.AddDbContext<UserContext>(ob =>
{
    ob.UseNpgsql(connectionString)
        //.UseLazyLoadingProxies()
        .LogTo(Console.WriteLine)
        .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetService<UserContext>();
    context.Database.Migrate();
    
    var roles = context.Roles.ToList();
    if (!roles.Any())
    {
        var user = context.Users.First();
        var role1 = new Role()
        {
            Name = "Admin"
        };
        var role2 = new Role()
        {
            Name = "Dev"
        };

        var userRoles = new List<UserRole>()
        {
            new UserRole(){ UserId = user.Id, RoleId = role1.Id},
            new UserRole(){ UserId = user.Id, RoleId = role2.Id},
        };
        context.AddRange(role1, role2);
        context.AddRange(userRoles);

        context.SaveChanges();
    }
    //context.Database.EnsureDeleted();
    //context.Database.EnsureCreated();

    // var users = new List<User>()
    // {
    //     new User() { FirstName = "Ali", LastName = "Valiev" },
    //     new User() { FirstName = "James", LastName = "Esh" },
    // };
    // context.AddRange(users);
    // context.SaveChanges();
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<GlobalExceptionMiddleware>();
// app.UseMiddleware<ApplicationKeyMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();