using NoisEmap.Domain.Entities;
using NoisEmap.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace NoisEmap.Application.Services
{
    public class SensorService
    {
        private readonly ISensorRepository _repository;
        private readonly ISensorMongoRepository _mongoRepository;

        public SensorService(ISensorRepository repository, ISensorMongoRepository mongoRepository)
        {
            _repository = repository;
            _mongoRepository = mongoRepository;
        }

        public IEnumerable<Sensor> GetAll(int page, int size)
            => _mongoRepository.GetAll()
                .Skip((page - 1) * size)
                .Take(size);

        public Sensor? GetById(int id)
            => _repository.GetById(id);

        public void Add(Sensor sensor)
        {
            if (sensor.Temperatura < -50 || sensor.Temperatura > 100)
                throw new ArgumentException("Temperatura inválida");
            _mongoRepository.Insert(sensor);
        }

        public void Update(Sensor sensor)
            => _repository.Update(sensor);

        public void Delete(int id)
            => _repository.Delete(id);
    }
}