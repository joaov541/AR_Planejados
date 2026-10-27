using System;
using System.Collections.Generic;

namespace AR_Planejados.Models;

public partial class Orcamento
{
    public int IdOrcamento { get; set; }

    public int IdCliente { get; set; }

    public string TipoAmbiente { get; set; } = null!;

    public string Descricao { get; set; } = null!;

    public decimal? ValorEstimado { get; set; }

    public string Status { get; set; } = null!;

    public DateTime DataSolicitacao { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;
}
