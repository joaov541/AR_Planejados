using System;
using System.Collections.Generic;

namespace AR_Planejados.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string Nome { get; set; } = null!;

    public string Telefone { get; set; } = null!;

    public string? Email { get; set; }

    public DateTime DataCadastro { get; set; }

    public virtual ICollection<Orcamento> Orcamentos { get; set; } = new List<Orcamento>();
}
