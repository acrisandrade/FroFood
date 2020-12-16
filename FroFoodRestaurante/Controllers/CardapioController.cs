using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Dominio_FroFood.Interfaces.Servico;
using Dominio_FroFood.Models;
using Dominio_FroFood.ViewModels;
using FroFoodCrossCut.Mappings;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FroFoodRestaurante.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardapioController : ControllerBase
    {
        public static IWebHostEnvironment _env;
        private readonly IItemService _itemService;
        private readonly IRestauranteService _restaurante;
        public CardapioController(IWebHostEnvironment env, IItemService itemService, IRestauranteService restaurante)
        {
            _env = env;
            _itemService = itemService;
            _restaurante = restaurante;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromForm] ItemView item)
        {
            try
            {
                var it = ViewToModel.ItemViewToItem(item);
                it.Restaurante = await _restaurante.BuscarAsync(item.RestauranteId);
                var i = await _itemService.AdicionarAsync(it);

                var image = item.Imagem;

                if (image.Length > 0)
                {
                    using (FileStream fileStream = System.IO.File.Create(_env.WebRootPath + "\\Galeria\\" + image.FileName))
                    {
                        image.CopyTo(fileStream);
                        fileStream.Flush();
                    }
                }
            } catch (Exception)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Item>> Get(Guid id)
        {
            var items = _itemService.BuscarItemsPorUsuario(id);
            return Ok(items);          
        }

    }
}
