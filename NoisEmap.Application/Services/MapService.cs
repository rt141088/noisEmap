using NoisEmap.Application.Dtos; // <-- CORRIGIDO: Deve ser Dtos (não DTOs)
using NoisEmap.Application.Interfaces;
using NoisEmap.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System; // <-- ESSENCIAL: Para usar 'NotImplementedException'

namespace NoisEmap.Application.Services
{
    public class MapService : IMapService
    {
        private readonly IMapRepository _mapRepository;

        public MapService(IMapRepository mapRepository)
        {
            _mapRepository = mapRepository;
        }

        public Task<IEnumerable<MapDto>> GetAllAsync()
        {
            // Substitua esta linha pela sua lógica real de mapeamento e retorno.
            throw new NotImplementedException();
        }

        public Task<MapDto?> GetByIdAsync(int id)
        {
            // Substitua esta linha pela sua lógica real.
            throw new NotImplementedException();
        }

        public Task AddAsync(CreateMapDto dto)
        {
            // Substitua esta linha pela sua lógica real.
            throw new NotImplementedException();
        }

        public Task UpdateAsync(int id, CreateMapDto dto)
        {
            // Substitua esta linha pela sua lógica real.
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            // Substitua esta linha pela sua lógica real.
            throw new NotImplementedException();
        }
    }
}