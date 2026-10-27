using System;
using System.Collections.Generic;

namespace AR_Planejados.Models;

public partial class Projeto
{
    public int IdProjeto { get; set; }

    public string NomeProjeto { get; set; } = null!;

    public string TipoAmbiente { get; set; } = null!;

    public string? Descricao { get; set; }

    public string? FotoProjeto { get; set; }

    public DateTime DataCadastro { get; set; }

    public bool Ativo { get; set; }
}
