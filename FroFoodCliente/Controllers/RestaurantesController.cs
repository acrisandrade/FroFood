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
    public class RestaurantesController : ControllerBase
    {
        private readonly IRestauranteService _context;

        public RestaurantesController(IRestauranteService context)
        {
            _context = context;
        }

        // GET: api/Restaurantes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Restaurante>>> GetRestaurante()
        {
            return Ok(await _context.BuscarAsync());
        }

        // GET: api/Restaurantes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Restaurante>> GetRestaurante(Guid id)
        {
            var restaurante = await _context.BuscarAsync(id);

            if (restaurante == null)
            {
                return NotFound();
            }

            return restaurante;
        }

        // PUT: api/Restaurantes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<Restaurante>> PutRestaurante(Restaurante restaurante)
        {
            var resultado = await _context.EditarAsync(restaurante);

            if (resultado != null)
            {
                return Ok(resultado);
            }
            
            return NoContent();
        }

        // POST: api/Restaurantes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Restaurante>> PostRestaurante(Restaurante restaurante)
        {
            var resultado = await _context.AdicionarAsync(restaurante);
            return CreatedAtAction("GetRestaurante", new { id = resultado.Id });
        }

        // DELETE: api/Restaurantes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteRestaurante(Guid id)
        {
            var resultado = await _context.ExcluirAsync(id);
            return resultado;
        }
                
    }
}
