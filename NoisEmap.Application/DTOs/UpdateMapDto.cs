namespace NoisEmap.Application.DTOs
{
    public class UpdateMapDto
    {
        public int Id { get; set; }
        // Adicionando '?' para permitir nulos (resolve CS8618)
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string? Address { get; set; }
    }
}