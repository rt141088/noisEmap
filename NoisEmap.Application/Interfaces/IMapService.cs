using NoisEmap.Application.Dtos; // <-- CORRIGIDO: Dtos (não DTOs)
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoisEmap.Application.Interfaces
{
    public interface IMapService
    {
        // Métodos assíncronos devem corresponder à sua implementação em MapService.cs
        Task<IEnumerable<MapDto>> GetAllAsync();
        Task<MapDto?> GetByIdAsync(int id);
        Task AddAsync(CreateMapDto dto);
        Task UpdateAsync(int id, CreateMapDto dto);
        Task DeleteAsync(int id);

        // Se você tinha MapDto GetMapById(int id); antes, ele deve ser removido ou atualizado para Task<MapDto?> GetByIdAsync(int id);
    }
}