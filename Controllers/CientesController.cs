using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using primerapi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace primerapi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly DbEmpresaContext _context;

        public ClientesController(DbEmpresaContext ctx)
        {
            _context = ctx;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> ListarClientes()
        {
            return await _context.Clientes.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return cliente;
        }

     
        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCliente), new { id = cliente.IdCliente }, cliente);
        }

       
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, Cliente cliente)
        {
            if (id != cliente.IdCliente)
            {
                return BadRequest();
            }

            _context.Entry(cliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Clientes.Any(e => e.IdCliente == id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

      
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

   
    [ApiController]
    [Route("api/[controller]")]
    public class PuestosController : ControllerBase
    {
        private readonly DbEmpresaContext _context;

        public PuestosController(DbEmpresaContext context)
        {
            _context = context;
        }

       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Puesto>>> GetPuestos()
        {
            return await _context.Puestos.ToListAsync();
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Puesto>> GetPuesto(int id)
        {
            var puesto = await _context.Puestos.FindAsync(id);
            if (puesto == null)
            {
                return NotFound();
            }
            return puesto;
        }

  [HttpPost]
        public async Task<ActionResult<Puesto>> PostPuesto(Puesto puesto)
        {
            _context.Puestos.Add(puesto);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPuesto), new { id = puesto.IdPuestos }, puesto);
        }

      
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPuesto(int id, Puesto puesto)
        {
            if (id != puesto.IdPuestos)
            {
                return BadRequest();
            }

            _context.Entry(puesto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Puestos.Any(e => e.IdPuestos == id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

       
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePuesto(int id)
        {
            var puesto = await _context.Puestos.FindAsync(id);
            if (puesto == null)
            {
                return NotFound();
            }

            _context.Puestos.Remove(puesto);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}