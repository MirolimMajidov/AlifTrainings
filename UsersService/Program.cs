using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using UsersService.Infrastructure;
using UsersService.Middlewares;
using UsersService.Repositories;
using UsersService.Services;
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
        .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});
//builder.Services.AddSingleton<IdProvider>();
builder.Services.AddScoped<IdProvider>();
//builder.Services.AddTransient<IdProvider>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped(typeof(ICRUDRepository<>), typeof(CRUDRepository<>));
builder.Services.AddScoped(typeof(IMemoryRepository<>), typeof(MemoryRepository<>));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetService<UserContext>();
    context.Database.Migrate();

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

app.MapGet("/status", () => "Working well");

app.MapGet("/GetUsers", (HttpContext httpContext, UserContext context) =>
{
    httpContext.Response.Headers.Add("Test", "123");
    
    return Results.Ok(context.Users);
});

app.Run();