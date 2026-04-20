using PagamentoMensageria.Web.Services;
using PagamentoMensageria.Web.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// D.I Services
builder.Services.AddTransient<IPagamentoService, PagamentoService>();

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
