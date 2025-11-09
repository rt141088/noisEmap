using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NoisEmap.Application.Interfaces;
using NoisEmap.Application.Services;
using NoisEmap.Domain.Interfaces;
using NoisEmap.Infrastructure.Clients;
using NoisEmap.Infrastructure.Data;
using NoisEmap.Infrastructure.Repositories;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// 🚀 CONFIGURAÇÃO DA PORTA 5055
builder.WebHost.UseUrls("http://localhost:5055");

// =====================================
// 📦 1. Configuração do Banco de Dados
// =====================================
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));


// =====================================
// 🌐 2. Injeção de Dependências (DI)
// =====================================
builder.Services.AddScoped<IMapRepository, MapRepository>();
builder.Services.AddScoped<IMapService, MapService>();

// CORREÇÃO FINAL dos Erros CS0029 e CS1662:
// Adicionei as chaves {} para transformar a lambda em um bloco de instrução (statement block).
builder.Services.AddHttpClient<IGeocodeClient, GeocodeClient>(client =>
{
    // A atribuição BaseAddress = new Uri(...) é uma instrução e requer o bloco {}.
    client.BaseAddress = new Uri("https://api.external-geocode.com/");
});


// =====================================
// 🔐 3. Configuração do CORS
// =====================================
const string CorsPolicy = "AllowAll";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: CorsPolicy, policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});


// =====================================
// ⚙️ 4. Configuração dos Controllers / JSON
// =====================================
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        options.JsonSerializerOptions.WriteIndented = true;
    });


// =====================================
// 🧭 5. Swagger (Documentação da API)
// =====================================
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "NoisEmap API",
        Version = "v1",
        Description = "API de gerenciamento de mapas e projetos - NoisEmap"
    });
});


// =====================================
// 🪵 6. Logging Estruturado
// =====================================
// Configuração padrão de logs estruturados com níveis de severidade.
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();


// =====================================
// 🚀 7. Montagem do App
// =====================================
var app = builder.Build();


// =====================================
// ⚠️ 8. Middleware Global de Erros
// =====================================
// Captura qualquer exceção não tratada e retorna JSON padronizado.
app.Use(async (context, next) =>
{
    try
    {
        await next();
    }
    catch (Exception ex)
    {
        var logger = context.RequestServices.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Erro não tratado: {Message}", ex.Message);

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        var response = new
        {
            success = false,
            message = "Ocorreu um erro interno no servidor.",
            detail = app.Environment.IsDevelopment() ? ex.Message : null
        };

        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
});


// =====================================
// 🌍 9. Configuração do Pipeline HTTP
// =====================================
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "NoisEmap API v1");
    });
}

app.UseHttpsRedirection();
app.UseCors(CorsPolicy);
app.UseAuthorization();
app.MapControllers();

app.Run();