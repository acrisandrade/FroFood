using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dominio_FroFood.Interfaces.Servico;
using Dominio_FroFood.Models;
using Dominio_FroFood.ViewModels;
using FroFoodCrossCut.Mappings;
using Microsoft.AspNetCore.Mvc;

namespace FroFoodRestaurante.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CadastroController : ControllerBase
    {
        private readonly IRestauranteService _service;

        public CadastroController(IRestauranteService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RestauranteView>>> GetRestaurante()
        {
            var resultado = await _service.BuscarAsync();
            return Ok(resultado);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RestauranteView>> GetRestaurante(Guid id)
        {
            var restaurante = await _service.BuscarAsync(id);
            return ViewToModel.RestauranteToRestauranteView(new RestauranteView(), restaurante);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<RestauranteView>> PutRestaurante(Restaurante Restaurante)
        {
            var resultado = await _service.EditarAsync(Restaurante);

            if (resultado != null)
            {
                return Ok(resultado);
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<RestauranteView>> PostRestaurante(Restaurante Restaurante)
        {
            var resultado = await _service.AdicionarAsync(Restaurante);

            return CreatedAtAction("GetRestaurante", new { id = resultado.Id });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteRestaurante(Guid id)
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
