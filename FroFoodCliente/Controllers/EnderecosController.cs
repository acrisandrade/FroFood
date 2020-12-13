using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dominio_FroFood.Models;
using Dominio_FroFood.Interfaces.Servico;

namespace FroFoodCliente.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecosController : ControllerBase
    {
        private readonly IEnderecoService _context;

        public EnderecosController(IEnderecoService context)
        {
            _context = context;
        }

        // GET: api/Enderecos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Endereco>>> GetEndereco()
        {
            var resultado = await _context.BuscarAsync();
            return Ok(resultado);
        }

        // GET: api/Enderecos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Endereco>> GetEndereco(Guid id)
        {
            var endereco = await _context.BuscarAsync(id);

            if (endereco == null)
            {
                return NotFound();
            }

            return endereco;
        }

        // PUT: api/Enderecos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<Endereco>> PutEndereco(Endereco endereco)
        {
            var resultado = await _context.EditarAsync(endereco);
            if (resultado != null)
            {
                return resultado;
            }

            return NoContent();
        }

        // POST: api/Enderecos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Endereco>> PostEndereco(Endereco endereco)
        {
            var resultado = await _context.AdicionarAsync(endereco);

            return CreatedAtAction("GetEndereco", new { id = endereco.Id });
        }

        // DELETE: api/Enderecos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteEndereco(Guid id)
        {
            var endereco = await _context.ExcluirAsync(id);
            return endereco;
        }

    }
}
