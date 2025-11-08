using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace NoisEmap.Infrastructure.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<NoisEmapDbContext>
    {
        public NoisEmapDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<NoisEmapDbContext>();

            optionsBuilder.UseSqlServer("Server=YASMTNVICTORIA\\SQLEXPRESS;Database=NoisEmapDB;Trusted_Connection=True;TrustServerCertificate=True;");

            return new NoisEmapDbContext(optionsBuilder.Options);
        }
    }
}
