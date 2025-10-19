using Microsoft.EntityFrameworkCore;
using NoisEmap.Infrastructure.Data;
using Microsoft.OpenApi.Models;
using NoisEmap.Application.Interfaces; // Para IMapService (Serviço)
using NoisEmap.Application.Services;   // Para MapService (Implementação)
using NoisEmap.Domain.Interfaces;      // Para IMapRepository e IGeocodeClient (Contratos)
using NoisEmap.Infrastructure.Repositories; // Para MapRepository
using System.Text.Json.Serialization;
using NoisEmap.Infrastructure.Clients; // Para GeocodeClient

// SOLUÇÃO PARA CONFLITO DE NOMES: Define um ALIAS para a classe MapRepository
// Esta linha é CRUCIAL para resolver o erro "MapRepository not found"
using MapRepositoryImpl = NoisEmap.Infrastructure.Repositories.MapRepository;


var builder = WebApplication.CreateBuilder(args);

// Configuração do Banco de Dados: USA SQL SERVER
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<NoisEmapDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

// Integração Externa (Cliente Geocode)
builder.Services.AddHttpClient<IGeocodeClient, GeocodeClient>(client =>
{
    client.BaseAddress = new Uri("https://api.external-geocode.com/");
});


// Injeção de Dependência (Corrigida e Completa)
// Usa o ALIAS para injetar o repositório
builder.Services.AddScoped<IMapRepository, MapRepositoryImpl>();
builder.Services.AddScoped<IMapService, MapService>();


// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddEndpointsApiExplorer();

// Configuração do Swagger/OpenAPI
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "NoisEmap API", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "NoisEmap API v1");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();