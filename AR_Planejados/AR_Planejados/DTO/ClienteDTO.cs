namespace ARPlanejados.DTOs
{
    public class ClienteDTO
    {
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}