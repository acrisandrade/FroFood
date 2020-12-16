using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Dominio_FroFood.Models;
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
        public CardapioController(IWebHostEnvironment env)
        {
            _env = env;
        }

        [HttpPost]
        public ActionResult Post([FromForm] Item item)
        {
            try
            {
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
        
    }
}
