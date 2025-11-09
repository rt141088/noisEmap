namespace NoisEmap.Application.DTOs
{
    public class LinkDto
    {
        public string Rel { get; set; } = string.Empty; // tipo de relação (ex: "self", "update")
        public string Href { get; set; } = string.Empty; // link completo
        public string Method { get; set; } = string.Empty; // método HTTP (GET, POST, PUT, DELETE)
    }
}
