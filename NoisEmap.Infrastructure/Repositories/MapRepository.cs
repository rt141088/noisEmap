using NoisEmap.Domain.Entities;
using NoisEmap.Domain.Interfaces;
using NoisEmap.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoisEmap.Infrastructure.Repositories
{
    public class MapRepository : IMapRepository
    {
        private readonly ApplicationDbContext _context;

        public MapRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Map>> GetAllAsync(int page, int pageSize, string? location)
        {
            var query = _context.Maps.AsQueryable();

            if (!string.IsNullOrEmpty(location))
                query = query.Where(m => m.Location.Contains(location));

            return await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Map> GetByIdAsync(int id)
        {
            return await _context.Maps.FindAsync(id);
        }

        public async Task<Map> AddAsync(Map map)
        {
            _context.Maps.Add(map);
            await _context.SaveChangesAsync();
            return map;
        }

        public async Task<Map> UpdateAsync(Map map)
        {
            _context.Maps.Update(map);
            await _context.SaveChangesAsync();
            return map;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Maps.FindAsync(id);
            if (entity != null)
            {
                _context.Maps.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
