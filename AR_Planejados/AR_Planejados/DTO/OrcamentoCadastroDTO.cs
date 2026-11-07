namespace ARPlanejados.DTOs
{
    public class OrcamentoCadastroDTO
    {
        public int IdCliente { get; set; }
        public string TipoAmbiente { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
    }
}