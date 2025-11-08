using NoisEmap.Domain.Interfaces;
using NoisEmap.Application.DTOs;
using NoisEmap.Application.Interfaces;
using NoisEmap.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoisEmap.Application.Services
{
    // O IMapService exige a implementação de todos os métodos abaixo
    public class MapService : IMapService
    {
        private readonly IMapRepository _mapRepository;

        public MapService(IMapRepository mapRepository)
        {
            _mapRepository = mapRepository;
        }

        // Método corrigido para usar os argumentos de paginação (GetAllAsync do IMapRepository)
        public async Task<IEnumerable<Map>> GetAllAsync()
        {
            // Usando os valores padrão para page, pageSize e locationFilter
            return await _mapRepository.GetAllAsync(1, 10, null);
        }

        public async Task<Map> GetByIdAsync(int id)
        {
            return await _mapRepository.GetByIdAsync(id);
        }

        public async Task<Map> AddAsync(CreateMapDto createMapDto)
        {
            var map = new Map
            {
                Name = createMapDto.Name,
                Description = createMapDto.Description,
                Latitude = createMapDto.Latitude,
                Longitude = createMapDto.Longitude,
                Address = createMapDto.Address,

                // CORREÇÃO CRÍTICA: Adicionando propriedades obrigatórias da Entidade Map
                Location = createMapDto.Address ?? "Localização Desconhecida",
                NoiseLevel = 0.0, // Valor padrão, pode ser ajustado
                RecordedAt = System.DateTime.UtcNow // Data e hora atuais
            };

            return await _mapRepository.AddAsync(map);
        }

        public async Task<Map> UpdateAsync(int id, UpdateMapDto updateMapDto)
        {
            var map = await _mapRepository.GetByIdAsync(id);
            if (map == null)
                return null;

            map.Name = updateMapDto.Name ?? map.Name;
            map.Description = updateMapDto.Description ?? map.Description;
            map.Latitude = updateMapDto.Latitude ?? map.Latitude;
            map.Longitude = updateMapDto.Longitude ?? map.Longitude;
            map.Address = updateMapDto.Address ?? map.Address;

            // Atualiza Location usando Address
            map.Location = updateMapDto.Address ?? map.Location;

            return await _mapRepository.UpdateAsync(map);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var map = await _mapRepository.GetByIdAsync(id);
            if (map == null)
                return false;

            // CORREÇÃO FINAL: Passando o ID (int) para o DeleteAsync do repositório
            await _mapRepository.DeleteAsync(id);
            return true;
        }
    }
}
