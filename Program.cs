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

// Database context
builder.Services.AddDbContext<NoisEmapDbContext>(options =>
    options.UseInMemoryDatabase("NoisEmapDb"));

// Dependency Injection
builder.Services.AddScoped<IMapRepository, MapRepository>();
builder.Services.AddScoped<MapService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
