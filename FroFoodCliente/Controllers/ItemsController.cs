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
    public class ItemsController : BaseController<Item, IItemService>
    {
        public ItemsController(IItemService service) : base(service)
        {
        }
        /*
        private readonly IItemService _service;

        public ItemsController(IItemService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetItem()
        {
            var resultado = await _service.BuscarAsync();
            return Ok(resultado);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetItem(Guid id)
        {
            var item = await _service.BuscarAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Item>> PutItem(Item item)
        {
            var resultado = await _service.EditarAsync(item);

            if (resultado != null)
            {
                return Ok(resultado);
            }

            return NoContent();
        }
        
        [HttpPost]
        public async Task<ActionResult<Item>> PostItem(Item item)
        {
            var resultado = await _service.AdicionarAsync(item);

            return CreatedAtAction("GetItem", new { id = resultado.Id });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteItem(Guid id)
        {
            var resultado = await _service.ExcluirAsync(id);

            if (resultado == false)
            {
                return NotFound();
            }

            return resultado;
        }

        [HttpPost("/buscaritems/")]
        public IEnumerable<Item> BuscarItems(string busca)
        {
            var resultado = _service.BuscarItems(busca);
            return resultado;
        }*/

    }
}
