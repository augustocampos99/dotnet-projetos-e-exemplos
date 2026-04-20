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
            ValidIssuer = "http://localhost:4200",
            ValidAudience = "http://localhost:4200",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("rD0vQkpTzqzd2P03YpvudaUq3VYtDhHF"))
        };
    });

builder.Services.AddAuthorization();

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
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "Empresas api") );
}

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
