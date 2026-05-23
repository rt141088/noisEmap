using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace NoisEmap.Domain.Entities
{
	public class Sensor
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		[BsonIgnoreIfDefault]
		public string? MongoId { get; set; }

		[BsonElement("Id")]
		public int Id { get; set; }

		public double Temperatura { get; set; }
		public double Umidade { get; set; }
	}
}