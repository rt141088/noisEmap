// NoisEmap.Application/Services/MapService.cs
using NoisEmap.Domain.Entities;
using NoisEmap.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoisEmap.Application.Services
{
    public class MapService
    {
        private readonly IMapRepository _mapRepository;

        public MapService(IMapRepository mapRepository)
        {
            _mapRepository = mapRepository;
        }

        public async Task<IEnumerable<MapProjects>> GetAllMapProjectsAsync()
        {
            return await _mapRepository.GetAllMapProjectsAsync();
        }

        public async Task<MapProjects> GetMapProjectByIdAsync(int id)
        {
            return await _mapRepository.GetMapProjectByIdAsync(id);
        }

        public async Task AddMapProjectAsync(MapProjects mapProject)
        {
            await _mapRepository.AddMapProjectAsync(mapProject);
        }

        // Adicione métodos similares para Marker
    }
}