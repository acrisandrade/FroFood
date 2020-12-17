using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio_FroFood.Interfaces.Servico;
using Dominio_FroFood.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FroFoodRestaurante.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantesController : ControllerBase
    {
        private readonly IRestauranteService _restaurante;

        public RestaurantesController(IRestauranteService restaurante)
        {
            _restaurante = restaurante;
        }

        // GET: api/<RestaurantesController>
        [HttpGet]
        public async Task<IEnumerable<Restaurante>> Get()
        {
            return await _restaurante.BuscarAsync();
        }

        // GET api/<RestaurantesController>/5
        [HttpGet("{id}")]
        public async Task<Restaurante> Get(Guid id)
        {
            return await _restaurante.BuscarAsync(id);
        }

        // POST api/<RestaurantesController>
        [HttpPost]
        public async Task<Restaurante> Post(Restaurante restaurante)
        {
            return await _restaurante.AdicionarAsync(restaurante);
        }

        // PUT api/<RestaurantesController>/5
        [HttpPut("{id}")]
        public async Task<Restaurante> Put(Restaurante restaurante)
        {
            return await _restaurante.EditarAsync(restaurante);
        }

        // DELETE api/<RestaurantesController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(Guid id)
        {
            return await _restaurante.ExcluirAsync(id);
        }
    }
}
