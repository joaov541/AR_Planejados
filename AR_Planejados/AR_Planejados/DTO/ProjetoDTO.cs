namespace ARPlanejados.DTOs
{
    public class ProjetoDTO
    {
        public int IdProjeto { get; set; }
        public int IdCliente { get; set; }
        public string NomeProjeto { get; set; }
        public string Descricao { get; set; }
        public string Status { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}