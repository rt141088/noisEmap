using System;
using System.ComponentModel.DataAnnotations;

namespace NoisEmap.Domain.Entities
{
	public class Map
	{
		[Key]
		public int Id { get; set; }

		// Propriedades Adicionadas/Corrigidas (resolveu o CS0117)
		public string? Name { get; set; } = string.Empty;
		public string? Description { get; set; } = string.Empty;
		public double Latitude { get; set; }
		public double Longitude { get; set; }
		public string? Address { get; set; } = string.Empty;

		// Propriedades Originais
		public string Location { get; set; } = string.Empty;
		public double NoiseLevel { get; set; }
		public DateTime RecordedAt { get; set; }
	}
}