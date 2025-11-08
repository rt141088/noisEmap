using Microsoft.EntityFrameworkCore;
using NoisEmap.Domain.Entities;

namespace NoisEmap.Infrastructure.Data
{
    public class NoisEmapDbContext : DbContext
    {
        public NoisEmapDbContext(DbContextOptions<NoisEmapDbContext> options)
            : base(options)
        {
        }

        public DbSet<Map> Maps { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Map>(builder =>
            {
                builder.HasKey(m => m.Id);
                builder.Property(m => m.Location).IsRequired().HasMaxLength(200);
                builder.Property(m => m.NoiseLevel).IsRequired();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
