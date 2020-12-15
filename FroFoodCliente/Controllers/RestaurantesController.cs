using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dominio_FroFood.Models;
using Dominio_FroFood.Interfaces.Servico;
using System.Text.Json;
using Dominio_FroFood.ViewModels;
using AutoMapper;

namespace FroFoodCliente.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantesController : ControllerBase
    {
        private readonly IRestauranteService _service;
        

        public RestaurantesController(IRestauranteService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Restaurante>>> GetRestaurante()
        {
            return Ok(await _service.BuscarAsync());
        }
        

        private RestauranteView RestauranteToRestauranteView(Restaurante restaurante)
        {
            var viewr = new RestauranteView();
            viewr.Nome = restaurante.Nome;
            viewr.Descricao = restaurante.Descricao;
            viewr.Id = restaurante.Id;
            foreach (var i in restaurante.Cardapio)
            {
                viewr.Cardapio.Add(new ItemView()
                {
                    Id = i.Id,
                    Nome = i.Nome,
                    Descricao = i.Descricao,
                    Valor = i.Valor,
                    Tamanho = i.Tamanho,
                    Categoria = i.Categoria,
                });
            }
            return viewr;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RestauranteView>> GetRestaurante(Guid id)
        {
            
            var r = await _service.BuscarAsync(id);
            var viewr = RestauranteToRestauranteView(r);
            if (r == null)
            {
                return NotFound();
            }
                    
            return viewr;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Restaurante>> PutRestaurante(Restaurante restaurante)
        {
            var resultado = await _service.EditarAsync(restaurante);

            if (resultado != null)
            {
                return Ok(resultado);
            }
            
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Restaurante>> PostRestaurante(Restaurante restaurante)
        {
            var resultado = await _service.AdicionarAsync(restaurante);

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
