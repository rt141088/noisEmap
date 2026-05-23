using System.Collections.Generic;
using NoisEmap.Domain.Entities;

namespace NoisEmap.Domain.Interfaces
{
	public interface ISensorRepository
	{
		IEnumerable<Sensor> GetAll(int page, int size);
		Sensor? GetById(int id);
		void Add(Sensor sensor);
		void Update(Sensor sensor);
		void Delete(int id);
	}
}