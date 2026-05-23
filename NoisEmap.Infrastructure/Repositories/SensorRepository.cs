using NoisEmap.Domain.Entities;
using NoisEmap.Domain.Interfaces;
using NoisEmap.Infrastructure.Data;

namespace NoisEmap.Infrastructure.Repositories
{
    public class SensorRepository : ISensorRepository
    {
        private readonly AppDbContext _context;

        public SensorRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Sensor> GetAll(int page, int size)
            => _context.Sensores.Skip((page - 1) * size).Take(size).ToList();

        public Sensor? GetById(int id)
            => _context.Sensores.FirstOrDefault(s => s.Id == id);

        public void Add(Sensor sensor)
        {
            _context.Sensores.Add(sensor);
            _context.SaveChanges();
        }

        public void Update(Sensor sensor)
        {
            _context.Sensores.Update(sensor);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var sensor = GetById(id);
            if (sensor != null)
            {
                _context.Sensores.Remove(sensor);
                _context.SaveChanges();
            }
        }
    }
}