using NoisEmap.Domain.Entities;
using System.Collections.Generic;

namespace NoisEmap.Application.DTOs
{
    public class MapDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string? Address { get; set; }
        public List<LinkDto>? Links { get; set; } // HATEOAS
    }
}
