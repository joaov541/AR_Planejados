
using AR_Planejados.Data;
using AR_Planejados.Models;
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
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Orcamento>>> Listar()
        {
            return await _context.Orcamentos
                .OrderByDescending(o => o.DataSolicitacao)
                .ToListAsync();
        }

        // GET: api/Orcamento/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Orcamento>> Buscar(int id)
        {
            var orcamento = await _context.Orcamentos.FindAsync(id);

            if (orcamento == null)
                return NotFound("Orçamento não encontrado.");

            return Ok(orcamento);
        }

        // POST: api/Orcamento
        [HttpPost]
        public async Task<ActionResult<Orcamento>> Cadastrar(
            Orcamento orcamento)
        {
            var cliente = await _context.Clientes
                .FindAsync(orcamento.IdCliente);

            if (cliente == null)
                return BadRequest("Cliente não encontrado.");

            orcamento.Status = "Pendente";
            orcamento.DataSolicitacao = DateTime.Now;

            _context.Orcamentos.Add(orcamento);

            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(Buscar),
                new { id = orcamento.IdOrcamento },
                orcamento
            );
        }

        // PUT: api/Orcamento/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Editar(
            int id, Orcamento orcamento)
        {
            if (id != orcamento.IdOrcamento)
                return BadRequest("ID inválido.");

            var existente = await _context.Orcamentos.FindAsync(id);

            if (existente == null)
                return NotFound("Orçamento não encontrado.");

            existente.TipoAmbiente = orcamento.TipoAmbiente;
            existente.Descricao = orcamento.Descricao;
            existente.ValorEstimado = orcamento.ValorEstimado;
            existente.Status = orcamento.Status;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Orcamento/5
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
