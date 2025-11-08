using NoisEmap.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoisEmap.Domain.Interfaces
{
    public interface IMapRepository
    {
        Task<IEnumerable<Map>> GetAllAsync(int page, int pageSize, string? location);
        Task<Map> GetByIdAsync(int id);
        Task<Map> AddAsync(Map map);
        Task<Map> UpdateAsync(Map map);
        Task DeleteAsync(int id);
    }
}
