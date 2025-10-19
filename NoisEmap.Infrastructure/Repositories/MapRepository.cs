using System.Collections.Generic;
using System.Threading.Tasks;
using NoisEmap.Domain.Entities;
using NoisEmap.Domain.Interfaces;

namespace NoisEmap.Infrastructure.Repositories
{
    public class MapRepository : IMapRepository
    {
        private readonly List<MapProject> _projects = new List<MapProject>();

        public async Task<IEnumerable<MapProject>> GetAllAsync()
        {
            // Simulação de acesso ao banco
            return await Task.FromResult(_projects);
        }

        public async Task<MapProject> GetByIdAsync(int id)
        {
            var project = _projects.Find(p => p.Id == id);
            return await Task.FromResult(project);
        }

        public async Task AddAsync(MapProject project)
        {
            _projects.Add(project);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(MapProject project)
        {
            var existing = _projects.Find(p => p.Id == project.Id);
            if (existing != null)
            {
                existing.NomeProjeto = project.NomeProjeto;
                existing.Descricao = project.Descricao;
            }
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(int id)
        {
            var project = _projects.Find(p => p.Id == id);
            if (project != null)
                _projects.Remove(project);

            await Task.CompletedTask;
        }
    }
}
