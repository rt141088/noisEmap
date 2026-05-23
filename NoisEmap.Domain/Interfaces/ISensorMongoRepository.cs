using System.Collections.Generic;
using NoisEmap.Domain.Entities;

namespace NoisEmap.Domain.Interfaces
{
	public interface ISensorMongoRepository
	{
		IEnumerable<Sensor> GetAll();
		void Insert(Sensor sensor);
	}
}