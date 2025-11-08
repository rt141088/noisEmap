
public class MapDto
{
    public int Id { get; set; }
    public string Location { get; set; } = string.Empty;
    public double NoiseLevel { get; set; }
    public DateTime RecordedAt { get; set; }

    // NOVO: Coleção de links
    public List<LinkDto> Links { get; set; } = new List<LinkDto>();
}