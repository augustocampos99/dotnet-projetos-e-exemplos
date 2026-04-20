using ExemploContatosApp.Data;
using ExemploContatosApp.Services;
using ExemploContatosApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// DI Context
var connectionString = builder.Configuration.GetConnectionString("PostgreSQLConnection");
builder.Services.AddDbContext<PostgreSQLContext>(options =>
        options.UseNpgsql(connectionString));


// D.I Services
builder.Services.AddTransient<IContatoService, ContatoService>();

// Configure GraphQL
// Libs: HotChocolate.AspNetCore (13.9.16) e HotChocolate.Data.EntityFramework (13.9.16)
builder.Services.AddGraphQLServer()
    .AddQueryType<GraphQLQueries>()
    .AddProjections()
    .AddFiltering()
    .AddSorting();

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

// Route GraphQL
app.MapGraphQL("/graphql");

app.UseAuthorization();

app.MapControllers();

app.Run();
