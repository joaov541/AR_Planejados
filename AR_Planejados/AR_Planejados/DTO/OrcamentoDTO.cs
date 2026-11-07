namespace ARPlanejados.DTOs
{
    public class OrcamentoDTO
    {
        public int IdOrcamento { get; set; }
        public int IdCliente { get; set; }
        public string TipoAmbiente { get; set; }
        public string Descricao { get; set; }
        public decimal? ValorEstimado { get; set; }
        public string Status { get; set; }
        public DateTime DataSolicitacao { get; set; }
    }
}