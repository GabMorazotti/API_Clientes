using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly DataContext _context;

        public ClienteController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cliente>>> GetAll()
        {
            return Ok(await _context.clientes.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetByID(int id)
        {            
            var cliente = await _context.clientes.FindAsync(id);
            if (cliente == null)
                return BadRequest("Cliente não encontrado.");
            return Ok(cliente);
        }

        [HttpPost]
        public async Task<ActionResult<List<Cliente>>> Post(Cliente model)
        {
            _context.clientes.Add(model);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<List<Cliente>>> Put(Cliente model)
        {
            var cliente = await _context.clientes.FindAsync(model.Id);
            if (cliente == null)
                return BadRequest("Cliente não encontrado.");

            cliente.nome = model.nome;
            cliente.cidade = model.cidade;
            cliente.telefone = model.telefone;
            cliente.email = model.email;
            cliente.cpf = model.cpf;

            await _context.SaveChangesAsync();

            return Ok(await _context.clientes.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Cliente>>> Delete(int id)
        {
            var cliente = await _context.clientes.FindAsync(id);
            if (cliente == null)
                return BadRequest("Cliente não encontrado.");

            _context.clientes.Remove(cliente);
            await _context.SaveChangesAsync();

            return Ok(await _context.clientes.ToListAsync());
        }

    }
}