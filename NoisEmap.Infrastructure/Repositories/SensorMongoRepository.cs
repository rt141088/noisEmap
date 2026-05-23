using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using NoisEmap.Domain.Entities;
using NoisEmap.Domain.Interfaces;

namespace NoisEmap.Infrastructure.Repositories
{
    public class SensorMongoRepository : ISensorMongoRepository
    {
        private readonly IMongoCollection<Sensor> _collection;

        public SensorMongoRepository(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["MongoDB:ConnectionString"]);
            var database = client.GetDatabase(configuration["MongoDB:Database"]);
            _collection = database.GetCollection<Sensor>("Sensores");
        }

        public IEnumerable<Sensor> GetAll()
            => _collection.Find(_ => true).ToList();

        public void Insert(Sensor sensor)
            => _collection.InsertOne(sensor);
    }
}