using NoisEmap.Application.Interfaces;

// Adicione as 3 linhas abaixo:
using NoisEmap.Domain.Entities;         // Para a classe Map
using NoisEmap.Application.DTOs;        // Para as DTOs (CreateMapDto e UpdateMapDto)
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoisEmap.Application.Interfaces
{
	public interface IMapService
	{
		Task<IEnumerable<Map>> GetAllAsync();
		Task<Map> GetByIdAsync(int id);
		Task<Map> AddAsync(CreateMapDto createMapDto);
		Task<Map> UpdateAsync(int id, UpdateMapDto updateMapDto);
		Task<bool> DeleteAsync(int id);
	}
}
