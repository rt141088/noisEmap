using Microsoft.EntityFrameworkCore;
using NoisEmap.Domain.Entities;
using NoisEmap.Domain.Interfaces;
using NoisEmap.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoisEmap.Infrastructure.Repositories
{
    public class MapRepository : IMapRepository
    {
        private readonly NoisEmapDbContext _context;

        public MapRepository(NoisEmapDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MapProjects>> GetAllMapProjectsAsync()
        {
            return await _context.MapProjects.ToListAsync();
        }

        public async Task<MapProjects> GetMapProjectByIdAsync(int id)
        {
            return await _context.MapProjects.FindAsync(id);
        }

        public async Task AddMapProjectAsync(MapProjects mapProject)
        {
            await _context.MapProjects.AddAsync(mapProject);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMapProjectAsync(MapProjects mapProject)
        {
            _context.MapProjects.Update(mapProject);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMapProjectAsync(int id)
        {
            var mapProject = await _context.MapProjects.FindAsync(id);
            if (mapProject != null)
            {
                _context.MapProjects.Remove(mapProject);
                await _context.SaveChangesAsync();
            }
        }
    }
}