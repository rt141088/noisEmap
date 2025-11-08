namespace NoisEmap.Application.DTOs
{
    public class MapDto
    {
        public int Id { get; set; }
        public string Location { get; set; } = string.Empty;
        public double NoiseLevel { get; set; }
        public DateTime RecordedAt { get; set; }
    }
}
