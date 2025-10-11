using Microsoft.EntityFrameworkCore;
using NoisEmap.Domain.Entities;

namespace NoisEmap.Infrastructure.Data
{
    public class NoisEmapDbContext : DbContext
    {
        public NoisEmapDbContext(DbContextOptions<NoisEmapDbContext> options) : base(options)
        {
        }

        public DbSet<MapProjects> MapProjects { get; set; }
        public DbSet<Marker> Markers { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurações de mapeamento, se necessário
        }
    }
}