using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Serilog.Events;
using Users.API.Services;
using UsersService.Infrastructure;
using UsersService.Infrastructure.Configs;
using UsersService.Middlewares;
using UsersService.Models;
using UsersService.Repositories;
using UsersService.Services;
using ILogger = Serilog.ILogger;

var builder = WebApplication.CreateBuilder(args);

ILogger logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console(LogEventLevel.Warning)
    .WriteTo.File("log.txt",
        outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
    .CreateLogger();

builder.Host.UseSerilog(logger);

var authOptions = builder.Configuration.GetSection(nameof(AuthOptions)).Get<AuthOptions>() ?? new();

builder.Services.AddSingleton(authOptions);
builder.Services.AddAuthorization();
builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = authOptions.Issuer,

            ValidateAudience = true,
            ValidAudience = authOptions.Audience,

            ValidateLifetime = true,
            RequireExpirationTime = true,

            ValidateIssuerSigningKey = true,
            IssuerSigningKey = authOptions.GetSymmetricSecurityKey(),
        });


var connectionString = builder.Configuration.GetSection("ConnectionString").Value;
builder.Services.AddDbContext<UserContext>(ob =>
{
    ob.UseNpgsql(connectionString)
        //.UseLazyLoadingProxies()
        .LogTo(Console.WriteLine)
        .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});
builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped(typeof(ICRUDRepository<>), typeof(CRUDRepository<>));
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddSingleton<IdProvider>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetService<UserContext>();
    context.Database.Migrate();

    var hasUsers = context.Users.Any();
    if (!hasUsers)
    {
        var firstUser = new User()
            { FirstName = "Ali", LastName = "Valiev", Age = 23, UserName = "ali", Password = "123" };
        var secondUser = new User()
            { FirstName = "James", LastName = "Esh", Age = 87, UserName = "james", Password = "123" };
        var users = new List<User>()
            { firstUser, secondUser };
        context.AddRange(users);
        
        var role1 = new Role()
        {
            Name = "Admin"
        };
        var role2 = new Role()
        {
            Name = "Dev"
        };
        var role3 = new Role()
        {
            Name = "User"
        };
        context.AddRange(role1, role2, role3);

        var userRoles = new List<UserRole>()
        {
            new UserRole() { UserId = firstUser.Id, RoleId = role1.Id },
            new UserRole() { UserId = firstUser.Id, RoleId = role2.Id },
            new UserRole() { UserId = secondUser.Id, RoleId = role3.Id },
        };
        context.AddRange(userRoles);
        context.SaveChanges();
    }
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