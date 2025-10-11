// NoisEmap.Domain/interfaces/IMapRepository.cs
using NoisEmap.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoisEmap.Domain.Interfaces
{
    public interface IMapRepository
    {
        Task<IEnumerable<MapProjects>> GetAllMapProjectsAsync();
        Task<MapProjects> GetMapProjectByIdAsync(int id);
        Task AddMapProjectAsync(MapProjects mapProject);
        Task UpdateMapProjectAsync(MapProjects mapProject);
        Task DeleteMapProjectAsync(int id);

        // Métodos para Marker
        Task<IEnumerable<Marker>> GetAllMarkersAsync();
        Task<Marker> GetMarkerByIdAsync(int id);
        Task AddMarkerAsync(Marker marker);
        Task UpdateMarkerAsync(Marker marker);
        Task DeleteMarkerAsync(int id);
    }
}