using NoisEmap.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoisEmap.Application.Interfaces
{
    public interface IMapService
    {
        Task<IEnumerable<MarkerDto>> GetMarkersAsync();
        Task<MarkerDto?> GetMarkerByIdAsync(int id);
        Task<MarkerDto> CreateMarkerAsync(CreateMarkerDto dto);
        Task UpdateMarkerAsync(int id, CreateMarkerDto dto);
        Task DeleteMarkerAsync(int id);
    }
}
