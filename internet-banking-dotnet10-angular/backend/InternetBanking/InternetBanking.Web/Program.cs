using InternetBanking.Application.Services;
using InternetBanking.Application.Services.Interfaces;
using InternetBanking.Domain.Repositories;
using InternetBanking.Infra.Context;
using InternetBanking.Infra.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// DI Context
var connectionString = builder.Configuration.GetConnectionString("PostgreSQLConnection");
builder.Services.AddDbContext<PostgreSQLContext>(options =>
        options.UseNpgsql(connectionString));

// D.I. Repositories
builder.Services.AddTransient<IUserRepository, UserRepository>();

// D.I. Services
builder.Services.AddTransient<IUserService, UserService>();

builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
