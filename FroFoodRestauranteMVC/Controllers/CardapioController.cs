using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Dominio_FroFood.Models;
using Dominio_FroFood.ViewModels;
using FroFoodRestauranteMVC.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace FroFoodRestauranteMVC.Controllers
{
    public class CardapioController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _contextAccessor;
        public CardapioController(IConfiguration configuration, IHttpContextAccessor contextAccessor, ApplicationDbContext context)
        {
            _configuration = configuration;
            _contextAccessor = contextAccessor;
            _context = context;
        }

        [HttpGet]
        //[Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        //[Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdicionarItem([FromForm] string nome, string descricao, string valor, string tamanho, string categoria, IFormFile imagem)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var item = new Item()
                {
                    Nome = nome,
                    Descricao = descricao,
                    Valor = Decimal.Parse(valor),
                    Tamanho = Int32.Parse(tamanho),
                    Categoria = categoria,
                };

                var ext = imagem.FileName.Split(".");
                var name = Guid.NewGuid().ToString() + "." + ext[1];

                var content = new MultipartFormDataContent();
                content.Add(new StringContent(nome), "Nome");
                content.Add(new StringContent(descricao), "Descricao");
                content.Add(new StringContent(valor), "Valor");
                content.Add(new StringContent(categoria), "Categoria");
                content.Add(new StringContent(tamanho), "Tamanho");
                content.Add(new StringContent(name), "NomeImagem");
                content.Add(new StreamContent(imagem.OpenReadStream()), "Imagem", name);
                
                using (var httpClient = new HttpClient())
                {
                    var url = _configuration["UrlAPICliente:UrlBase"] + "/Cardapio";
                    using (var resposta = await httpClient.PostAsync(url, content))
                    {
                        string respostaApi = await resposta.Content.ReadAsStringAsync();
                        var itemView = JsonConvert.DeserializeObject<ItemView>(respostaApi);
                    }
                }

            } catch
            {
                return BadRequest();
            }
            return View();
        }

        
    }
}
