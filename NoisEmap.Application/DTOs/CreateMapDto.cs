namespace NoisEmap.Application.DTOs
{
    public class CreateMapDto
    {
        // Adicionando '?' para permitir que a string seja nula (resolve CS8618)
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string? Address { get; set; }
    }
}   