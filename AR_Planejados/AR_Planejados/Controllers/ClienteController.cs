
using AR_Planejados.Data;
using AR_Planejados.Models;
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
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> Listar()
        {
            return await _context.Clientes.ToListAsync();
        }

        // GET: api/Cliente/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> Buscar(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
                return NotFound("Cliente não encontrado.");

            return Ok(cliente);
        }

        // POST: api/Cliente
        [HttpPost]
        public async Task<ActionResult<Cliente>> Cadastrar(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(Buscar),
                new { id = cliente.IdCliente },
                cliente
            );
        }

        // PUT: api/Cliente/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Editar(int id, Cliente cliente)
        {
            if (id != cliente.IdCliente)
                return BadRequest("ID inválido.");

            var clienteExistente = await _context.Clientes.FindAsync(id);

            if (clienteExistente == null)
                return NotFound("Cliente não encontrado.");

            clienteExistente.Nome = cliente.Nome;
            clienteExistente.Telefone = cliente.Telefone;
            clienteExistente.Email = cliente.Email;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Cliente/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
                return NotFound("Cliente não encontrado.");

            bool possuiOrcamentos = await _context.Orcamentos
                .AnyAsync(o => o.IdCliente == id);

            if (possuiOrcamentos)
                return Conflict("Não é possível excluir um cliente que possui orçamentos.");

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
