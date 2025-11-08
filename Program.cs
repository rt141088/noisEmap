using Microsoft.EntityFrameworkCore;
using NoisEmap.Infrastructure.Data;
using NoisEmap.Application.Services;
using NoisEmap.Application.Interfaces;
using NoisEmap.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database context (InMemory)
builder.Services.AddDbContext<NoisEmapDbContext>(options =>
    options.UseInMemoryDatabase("NoisEmapDb"));

// Dependency Injection (camadas ligadas)
builder.Services.AddScoped<IMapRepository, MapRepository>();
builder.Services.AddScoped<IMapService, MapService>();

// (Opcional) AutoMapper — se quiser usar depois para mapear DTOs automaticamente
// builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// (Recomendado pelo template .NET)
app.UseAuthorization();

app.MapControllers();

app.Run();
