namespace ARPlanejados.DTOs
{
    public class ProjetoDTO
    {
        public int IdProjeto { get; set; }
        public string NomeProjeto { get; set; }
        public string TipoAmbiente { get; set; }
        public string Descricao { get; set; }
        public string FotoProjeto { get; set; }
        public string Status { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}