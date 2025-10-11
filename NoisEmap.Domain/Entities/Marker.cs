namespace NoisEmap.Domain.Entities
{
    public class Marker
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Description { get; set; }
        // Relacionamento com MapProjects (se houver)
        public int MapProjectId { get; set; }
        public MapProjects MapProject { get; set; }
    }
}