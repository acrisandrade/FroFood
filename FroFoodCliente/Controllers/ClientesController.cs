using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dominio_FroFood.Models;
using Dominio_FroFood.Interfaces.Servico;

namespace FroFoodCliente.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _service;

        public ClientesController(IClienteService service)
        {
            _service = service;
        }

        // GET: api/Clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetCliente()
        {
            var resultado = await _service.BuscarAsync();
            return Ok(resultado);
        }

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(Guid id)
        {
            var cliente = await _service.BuscarAsync(id);
            return cliente;
        }

        // PUT: api/Clientes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<Cliente>> PutCliente(Cliente cliente)
        {
            var resultado = await _service.EditarAsync(cliente);

            if (resultado != null)
            {
                return Ok(resultado);
            }

            return NoContent();
        }

        // POST: api/Clientes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
        {
            var resultado = await _service.AdicionarAsync(cliente);

            return CreatedAtAction("GetCliente", new { id = resultado.Id });
        }

        // DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteCliente(Guid id)
        {
            var resultado = await _service.ExcluirAsync(id);

            if (resultado == false)
            {
                return NotFound();
            }

            return resultado;
        }
               
    }
}
