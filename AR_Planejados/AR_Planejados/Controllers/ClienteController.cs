
using AR_Planejados.Data;
using AR_Planejados.Models;
using ARPlanejados.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AR_Planejados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ARPlanejadosContext _context;

        public ClienteController(ARPlanejadosContext context)
        {
            _context = context;
        }

        // GET: api/Cliente
        // Lista todos os clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteDTO>>> Listar()
        {
            var clientes = await _context.Clientes
                .Select(c => new ClienteDTO
                {
                    IdCliente = c.IdCliente,
                    Nome = c.Nome,
                    Telefone = c.Telefone,
                    Email = c.Email,
                    DataCadastro = c.DataCadastro
                })
                .ToListAsync();

            return Ok(clientes);
        }

        // GET: api/Cliente/5
        // Busca um cliente pelo ID
        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteDTO>> Buscar(int id)
        {
            var cliente = await _context.Clientes
                .Where(c => c.IdCliente == id)
                .Select(c => new ClienteDTO
                {
                    IdCliente = c.IdCliente,
                    Nome = c.Nome,
                    Telefone = c.Telefone,
                    Email = c.Email,
                    DataCadastro = c.DataCadastro
                })
                .FirstOrDefaultAsync();

            if (cliente == null)
                return NotFound("Cliente não encontrado.");

            return Ok(cliente);
        }

        // GET: api/Cliente/5/editar
        // Busca os dados para preencher o formulário de edição
        [HttpGet("{id}/editar")]
        public async Task<ActionResult<ClienteEditarDTO>> BuscarParaEditar(int id)
        {
            var cliente = await _context.Clientes
                .Where(c => c.IdCliente == id)
                .Select(c => new ClienteEditarDTO
                {
                    Nome = c.Nome,
                    Telefone = c.Telefone,
                    Email = c.Email
                })
                .FirstOrDefaultAsync();

            if (cliente == null)
                return NotFound("Cliente não encontrado.");

            return Ok(cliente);
        }

        // POST: api/Cliente
        // Cadastra um novo cliente
        [HttpPost]
        public async Task<ActionResult<ClienteDTO>> Cadastrar(
            ClienteCadastroDTO clienteDTO)
        {
            var cliente = new Cliente
            {
                Nome = clienteDTO.Nome,
                Telefone = clienteDTO.Telefone,
                Email = clienteDTO.Email
            };

            _context.Clientes.Add(cliente);

            await _context.SaveChangesAsync();

            var resposta = new ClienteDTO
            {
                IdCliente = cliente.IdCliente,
                Nome = cliente.Nome,
                Telefone = cliente.Telefone,
                Email = cliente.Email,
                DataCadastro = cliente.DataCadastro
            };

            return CreatedAtAction(
                nameof(Buscar),
                new { id = cliente.IdCliente },
                resposta
            );
        }

        // PUT: api/Cliente/5
        // Atualiza os dados de um cliente
        [HttpPut("{id}")]
        public async Task<ActionResult<ClienteDTO>> Editar(
            int id,
            ClienteEditarDTO clienteDTO)
        {
            var clienteExistente = await _context.Clientes.FindAsync(id);

            if (clienteExistente == null)
                return NotFound("Cliente não encontrado.");

            clienteExistente.Nome = clienteDTO.Nome;
            clienteExistente.Telefone = clienteDTO.Telefone;
            clienteExistente.Email = clienteDTO.Email;

            await _context.SaveChangesAsync();

            var resposta = new ClienteDTO
            {
                IdCliente = clienteExistente.IdCliente,
                Nome = clienteExistente.Nome,
                Telefone = clienteExistente.Telefone,
                Email = clienteExistente.Email,
                DataCadastro = clienteExistente.DataCadastro
            };

            return Ok(resposta);
        }

        // DELETE: api/Cliente/5
        // Exclui um cliente
        [HttpDelete("{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
                return NotFound("Cliente não encontrado.");

            bool possuiOrcamentos = await _context.Orcamentos
                .AnyAsync(o => o.IdCliente == id);

            if (possuiOrcamentos)
                return Conflict(
                    "Não é possível excluir um cliente que possui orçamentos."
                );

            _context.Clientes.Remove(cliente);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
