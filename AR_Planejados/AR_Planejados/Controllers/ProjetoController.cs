
using AR_Planejados.Data;
using AR_Planejados.Models;
using ARPlanejados.DTOs;
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
        // Lista todos os projetos ativos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjetoDTO>>> Listar()
        {
            var projetos = await _context.Projetos
                .Where(p => p.Ativo)
                .Select(p => new ProjetoDTO
                {
                    IdProjeto = p.IdProjeto,
                    NomeProjeto = p.NomeProjeto,
                    TipoAmbiente = p.TipoAmbiente,
                    Descricao = p.Descricao,
                    FotoProjeto = p.FotoProjeto,
                    Status = p.Ativo ? "Ativo" : "Inativo",
                    DataCadastro = p.DataCadastro
                })
                .ToListAsync();

            return Ok(projetos);
        }

        // GET: api/Projeto/5
        // Busca um projeto pelo ID
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjetoDTO>> Buscar(int id)
        {
            var projeto = await _context.Projetos
                .Where(p => p.IdProjeto == id && p.Ativo)
                .Select(p => new ProjetoDTO
                {
                    IdProjeto = p.IdProjeto,
                    NomeProjeto = p.NomeProjeto,
                    TipoAmbiente = p.TipoAmbiente,
                    Descricao = p.Descricao,
                    FotoProjeto = p.FotoProjeto,
                    Status = p.Ativo ? "Ativo" : "Inativo",
                    DataCadastro = p.DataCadastro
                })
                .FirstOrDefaultAsync();

            if (projeto == null)
                return NotFound("Projeto não encontrado.");

            return Ok(projeto);
        }

        // POST: api/Projeto
        // Cadastra um novo projeto
        [HttpPost]
        public async Task<ActionResult<ProjetoDTO>> Cadastrar(
            ProjetoCadastroDTO projetoDTO)
        {
            var projeto = new Projeto
            {
                NomeProjeto = projetoDTO.NomeProjeto,
                TipoAmbiente = projetoDTO.TipoAmbiente,
                Descricao = projetoDTO.Descricao,
                FotoProjeto = projetoDTO.FotoProjeto,
                Ativo = true,
                DataCadastro = DateTime.Now
            };

            _context.Projetos.Add(projeto);

            await _context.SaveChangesAsync();

            var resposta = new ProjetoDTO
            {
                IdProjeto = projeto.IdProjeto,
                NomeProjeto = projeto.NomeProjeto,
                TipoAmbiente = projeto.TipoAmbiente,
                Descricao = projeto.Descricao,
                FotoProjeto = projeto.FotoProjeto,
                Status = projeto.Ativo ? "Ativo" : "Inativo",
                DataCadastro = projeto.DataCadastro
            };

            return CreatedAtAction(
                nameof(Buscar),
                new { id = projeto.IdProjeto },
                resposta
            );
        }

        // PUT: api/Projeto/5
        // Atualiza as informações do projeto
        [HttpPut("{id}")]
        public async Task<ActionResult<ProjetoDTO>> Editar(
            int id,
            ProjetoEditarDTO projetoDTO)
        {
            var existente = await _context.Projetos.FindAsync(id);

            if (existente == null)
                return NotFound("Projeto não encontrado.");

            existente.NomeProjeto = projetoDTO.NomeProjeto;
            existente.TipoAmbiente = projetoDTO.TipoAmbiente;
            existente.Descricao = projetoDTO.Descricao;
            existente.FotoProjeto = projetoDTO.FotoProjeto;

            await _context.SaveChangesAsync();

            var resposta = new ProjetoDTO
            {
                IdProjeto = existente.IdProjeto,
                NomeProjeto = existente.NomeProjeto,
                TipoAmbiente = existente.TipoAmbiente,
                Descricao = existente.Descricao,
                FotoProjeto = existente.FotoProjeto,
                Status = existente.Ativo ? "Ativo" : "Inativo",
                DataCadastro = existente.DataCadastro
            };

            return Ok(resposta);
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
