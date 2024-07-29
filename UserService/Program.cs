using Microsoft.EntityFrameworkCore;
using UserService.Infrastructure;
using UserService.Middlewares;
using UserService.Models;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetSection("ConnectionString").Value;
builder.Services.AddDbContext<UserContext>(ob =>
{
    ob.UseNpgsql(connectionString)
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