
using AR_Planejados.Data;
using AR_Planejados.Models;
using ARPlanejados.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AR_Planejados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrcamentoController : ControllerBase
    {
        private readonly ARPlanejadosContext _context;

        public OrcamentoController(ARPlanejadosContext context)
        {
            _context = context;
        }

        // GET: api/Orcamento
        // Lista todos os orçamentos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrcamentoDTO>>> Listar()
        {
            var orcamentos = await _context.Orcamentos
                .OrderByDescending(o => o.DataSolicitacao)
                .Select(o => new OrcamentoDTO
                {
                    IdOrcamento = o.IdOrcamento,
                    IdCliente = o.IdCliente,
                    TipoAmbiente = o.TipoAmbiente,
                    Descricao = o.Descricao,
                    ValorEstimado = o.ValorEstimado,
                    Status = o.Status,
                    DataSolicitacao = o.DataSolicitacao
                })
                .ToListAsync();

            return Ok(orcamentos);
        }

        // GET: api/Orcamento/5
        // Busca um orçamento pelo ID
        [HttpGet("{id}")]
        public async Task<ActionResult<OrcamentoDTO>> Buscar(int id)
        {
            var orcamento = await _context.Orcamentos
                .Where(o => o.IdOrcamento == id)
                .Select(o => new OrcamentoDTO
                {
                    IdOrcamento = o.IdOrcamento,
                    IdCliente = o.IdCliente,
                    TipoAmbiente = o.TipoAmbiente,
                    Descricao = o.Descricao,
                    ValorEstimado = o.ValorEstimado,
                    Status = o.Status,
                    DataSolicitacao = o.DataSolicitacao
                })
                .FirstOrDefaultAsync();

            if (orcamento == null)
                return NotFound("Orçamento não encontrado.");

            return Ok(orcamento);
        }

        // GET: api/Orcamento/5/editar
        // Busca os dados antes da edição
        [HttpGet("{id}/editar")]
        public async Task<ActionResult<OrcamentoDTO>> BuscarParaEditar(int id)
        {
            var orcamento = await _context.Orcamentos
                .Where(o => o.IdOrcamento == id)
                .Select(o => new OrcamentoDTO
                {
                    IdOrcamento = o.IdOrcamento,
                    IdCliente = o.IdCliente,
                    TipoAmbiente = o.TipoAmbiente,
                    Descricao = o.Descricao,
                    ValorEstimado = o.ValorEstimado,
                    Status = o.Status,
                    DataSolicitacao = o.DataSolicitacao
                })
                .FirstOrDefaultAsync();

            if (orcamento == null)
                return NotFound("Orçamento não encontrado.");

            return Ok(orcamento);
        }

        // POST: api/Orcamento
        // Cadastra um novo orçamento
        [HttpPost]
        public async Task<ActionResult<OrcamentoDTO>> Cadastrar(
            OrcamentoCadastroDTO orcamentoDTO)
        {
            var cliente = await _context.Clientes
                .FindAsync(orcamentoDTO.IdCliente);

            if (cliente == null)
                return BadRequest("Cliente não encontrado.");

            var orcamento = new Orcamento
            {
                IdCliente = orcamentoDTO.IdCliente,
                TipoAmbiente = orcamentoDTO.TipoAmbiente,
                Descricao = orcamentoDTO.Descricao,
                Status = "Ativo",
                DataSolicitacao = DateTime.Now
            };

            _context.Orcamentos.Add(orcamento);

            await _context.SaveChangesAsync();

            var resposta = new OrcamentoDTO
            {
                IdOrcamento = orcamento.IdOrcamento,
                IdCliente = orcamento.IdCliente,
                TipoAmbiente = orcamento.TipoAmbiente,
                Descricao = orcamento.Descricao,
                ValorEstimado = orcamento.ValorEstimado,
                Status = orcamento.Status,
                DataSolicitacao = orcamento.DataSolicitacao
            };

            return CreatedAtAction(
                nameof(Buscar),
                new { id = orcamento.IdOrcamento },
                resposta
            );
        }

        // PUT: api/Orcamento/5
        // Atualiza um orçamento
        // PUT: api/Orcamento/5
        // Atualiza somente as informações da solicitação
        [HttpPut("{id}")]
        public async Task<ActionResult<OrcamentoDTO>> Editar(
            int id,
            OrcamentoEditarDTO orcamentoDTO)
        {
            var existente = await _context.Orcamentos.FindAsync(id);

            if (existente == null)
                return NotFound("Orçamento não encontrado.");

            existente.TipoAmbiente = orcamentoDTO.TipoAmbiente;
            existente.Descricao = orcamentoDTO.Descricao;

            await _context.SaveChangesAsync();

            var resposta = new OrcamentoDTO
            {
                IdOrcamento = existente.IdOrcamento,
                IdCliente = existente.IdCliente,
                TipoAmbiente = existente.TipoAmbiente,
                Descricao = existente.Descricao,
                ValorEstimado = existente.ValorEstimado,
                Status = existente.Status,
                DataSolicitacao = existente.DataSolicitacao
            };

            return Ok(resposta);
        }

        // DELETE: api/Orcamento/5
        // Exclui um orçamento
        [HttpDelete("{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            var orcamento = await _context.Orcamentos.FindAsync(id);

            if (orcamento == null)
                return NotFound("Orçamento não encontrado.");

            _context.Orcamentos.Remove(orcamento);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
