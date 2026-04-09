using EmpresaAppCleanArchitecture.Application.Services;
using EmpresaAppCleanArchitecture.Application.Services.Interfaces;
using EmpresaAppCleanArchitecture.Domain.Interfaces.Repositories;
using EmpresaAppCleanArchitecture.Infra.Context;
using EmpresaAppCleanArchitecture.Infra.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// DI Context
var connectionString = builder.Configuration.GetConnectionString("PostgreSQLConnection");
builder.Services.AddDbContext<PostgreSQLContext>(options =>
        options.UseNpgsql(connectionString));

// D.I. Repositories
builder.Services.AddTransient<IFuncionarioRepository, FuncionarioRepository>();
builder.Services.AddTransient<IDepartamentoRepository, DepartamentoRepository>();
builder.Services.AddTransient<ICargoRepository, CargoRepository>();

// D.I. Services
builder.Services.AddTransient<IFuncionarioService, FuncionarioService>();
builder.Services.AddTransient<IDepartamentoService, DepartamentoService>();
builder.Services.AddTransient<ICargoService, CargoService>();
builder.Services.AddTransient<IAuthService, AuthService>();

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

// Configure Auth Token
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "https://abtestfactory.com",
            ValidAudience = "https://abtestfactory.com",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("rD0vQkpTzqzd2P03YpvudaUq3VYtDhHF"))
        };
    });

builder.Services.AddAuthorization();


var app = builder.Build();

// Config CORS (Change for PROD on publish)
app.UseCors("EnableAllOrigins");

app.UseAuthentication();
app.UseAuthorization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "Empresas api") );
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
