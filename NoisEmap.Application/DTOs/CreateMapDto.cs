namespace NoisEmap.Application.DTOs
{
    public class CreateMarkerDto
    {
        public string Nome { get; set; } = string.Empty;
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
