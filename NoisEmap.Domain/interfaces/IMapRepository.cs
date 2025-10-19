using System.Collections.Generic;
using System.Threading.Tasks;
using NoisEmap.Domain.Entities;

namespace NoisEmap.Domain.Interfaces
{
    public interface IMapRepository
    {
        Task<IEnumerable<MapProject>> GetAllAsync();
        Task<MapProject> GetByIdAsync(int id);
        Task AddAsync(MapProject project);
        Task UpdateAsync(MapProject project);
        Task DeleteAsync(int id);
    }
}
