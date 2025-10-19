namespace NoisEmap.Application.Dtos // <--- ATENÇÃO AO NOME: Dtos
{
    public class CreateMapDto
    {
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
    }
}