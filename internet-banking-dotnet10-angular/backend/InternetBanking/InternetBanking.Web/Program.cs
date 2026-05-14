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

// Config CORS
builder.Services.AddCors(options =>
    options.AddPolicy("EnableAllOrigins",
        builder =>
        {
            builder.WithOrigins("*")
            .AllowAnyMethod()
            .AllowAnyHeader();
        })
);

// Add OpenApi
builder.Services.AddOpenApi();

var app = builder.Build();

// Config CORS (Change for PROD on publish)
app.UseCors("EnableAllOrigins");

// Configure Swagger (Swashbuckle.AspNetCore.SwaggerUI).
// http://localhost:5239/swagger/index.html
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "Empresas api"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
