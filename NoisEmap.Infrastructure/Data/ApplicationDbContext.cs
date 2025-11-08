using Microsoft.EntityFrameworkCore;
using NoisEmap.Domain.Entities;

namespace NoisEmap.Infrastructure.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		public DbSet<Map> Maps { get; set; }
	}
}
