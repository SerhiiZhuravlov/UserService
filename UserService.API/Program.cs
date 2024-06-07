using API;
using Application.Interfaces;
using Application.Validators;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using UserService.Application.Interfaces.Database;
using UserService.Infrastructure.Database.Repositories;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserService, Application.Services.UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<UserValidator>();

builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new MappingProfile());
});

var connectionString = builder.Configuration.GetConnectionString("UserDbConnection");

builder.Services.AddPooledDbContextFactory<UserServiceDbContext>(builder => builder.UseSqlServer(connectionString));

var app = builder.Build();

using var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
var context = await serviceScope.ServiceProvider.GetRequiredService<IDbContextFactory<UserServiceDbContext>>().CreateDbContextAsync();
var pendingMigrations = await context.Database.GetPendingMigrationsAsync();
if (pendingMigrations.Any())
    await context.Database.MigrateAsync();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();