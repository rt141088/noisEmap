using Microsoft.EntityFrameworkCore;
using NoisEmap.Domain.Entities;

namespace NoisEmap.Infrastructure.Data
{
    public class NoisEmapDbContext : DbContext
    {
        public NoisEmapDbContext(DbContextOptions<NoisEmapDbContext> options)
            : base(options) { }

        public DbSet<MapProject> MapProjects => Set<MapProject>();
        public DbSet<Marker> Markers => Set<Marker>();
    }
}
