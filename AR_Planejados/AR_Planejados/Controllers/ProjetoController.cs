
using AR_Planejados.Data;
using AR_Planejados.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AR_Planejados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetoController : ControllerBase
    {
        private readonly ARPlanejadosContext _context;

        public ProjetoController(ARPlanejadosContext context)
        {
            _context = context;
        }

        // GET: api/Projeto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Projeto>>> Listar()
        {
            return await _context.Projetos
                .Where(p => p.Ativo)
                .ToListAsync();
        }

        // GET: api/Projeto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Projeto>> Buscar(int id)
        {
            var projeto = await _context.Projetos.FindAsync(id);

            if (projeto == null)
                return NotFound("Projeto não encontrado.");

            return Ok(projeto);
        }

        // POST: api/Projeto
        [HttpPost]
        public async Task<ActionResult<Projeto>> Cadastrar(Projeto projeto)
        {
            _context.Projetos.Add(projeto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(Buscar),
                new { id = projeto.IdProjeto },
                projeto
            );
        }

        // PUT: api/Projeto/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Editar(int id, Projeto projeto)
        {
            if (id != projeto.IdProjeto)
                return BadRequest("ID inválido.");

            var projetoExistente = await _context.Projetos.FindAsync(id);

            if (projetoExistente == null)
                return NotFound("Projeto não encontrado.");

            projetoExistente.NomeProjeto = projeto.NomeProjeto;
            projetoExistente.TipoAmbiente = projeto.TipoAmbiente;
            projetoExistente.Descricao = projeto.Descricao;
            projetoExistente.FotoProjeto = projeto.FotoProjeto;
            projetoExistente.Ativo = projeto.Ativo;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Projeto/5
        // Desativa o projeto em vez de apagar do banco
        [HttpDelete("{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            var projeto = await _context.Projetos.FindAsync(id);

            if (projeto == null)
                return NotFound("Projeto não encontrado.");

            projeto.Ativo = false;

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
