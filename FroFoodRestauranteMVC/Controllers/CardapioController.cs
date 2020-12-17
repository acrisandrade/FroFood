using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Dominio_FroFood.Interfaces.Servico;
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
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Item>>> GetAll()
        {
            var items = new List<Item>();
            var email = _contextAccessor.HttpContext.User.Identity.Name;
            var user = _context.Users.FirstOrDefault(u => u.UserName == email);

            using (var httpClient = new HttpClient())
            {
                var url = _configuration["UrlAPICliente:UrlBase"] + $"/Cardapio/{user.Id}";
                using (var resposta = await httpClient.GetAsync(url))
                {
                    string respostaApi = await resposta.Content.ReadAsStringAsync();
                    items = JsonConvert.DeserializeObject<List<Item>>(respostaApi);
                }
            }
            return View(items);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdicionarItem([FromForm] string nome, string descricao, string valor, string tamanho, string categoria, IFormFile imagem)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var email = _contextAccessor.HttpContext.User.Identity.Name;
                var user = _context.Users.FirstOrDefault(u => u.UserName == email);

                var item = new ItemView()
                {
                    Nome = nome,
                    Descricao = descricao,
                    Valor = Decimal.Parse(valor),
                    Tamanho = Int32.Parse(tamanho),
                    Categoria = categoria,
                };

                var ext = imagem.FileName.Split(".");
                var name = Guid.NewGuid().ToString() + "." + ext[1];
                var r = (Restaurante)TempData["r"];
                
                var content = new MultipartFormDataContent();
                content.Add(new StringContent(nome), "Nome");
                content.Add(new StringContent(descricao), "Descricao");
                content.Add(new StringContent(valor), "Valor");
                content.Add(new StringContent(categoria), "Categoria");
                content.Add(new StringContent(tamanho), "Tamanho");
                content.Add(new StringContent(name), "NomeImagem");
                content.Add(new StringContent(user.Id), "RestauranteId");
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

            } catch(Exception e)
            {
                return BadRequest();
            }
            return View();
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<ItemView>> EditarCardapio(Guid id)
        {
            var itemView = new ItemView();
            using (var httpClient = new HttpClient())
            {
                var url = _configuration["UrlAPICliente:UrlBase"] + $"/Cardapio/getItem/{id}";
                using (var resposta = await httpClient.GetAsync(url))
                {
                    string respostaApi = await resposta.Content.ReadAsStringAsync();
                    itemView = JsonConvert.DeserializeObject<ItemView>(respostaApi);
                }
                
            }
            return View(itemView);

        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Item>> EditarCardapio(Item item)
        {

            var email = _contextAccessor.HttpContext.User.Identity.Name;
            var user = _context.Users.FirstOrDefault(u => u.UserName == email);

            var extAtual = item.Imagem.FileName.Split(".");
            var extOld = item.NomeImagem.Split(".");
            var name = extOld[0] + "." + extAtual[1];

            var content = new MultipartFormDataContent();
            content.Add(new StringContent(item.Id.ToString()), "Id");
            content.Add(new StringContent(item.Nome), "Nome");
            content.Add(new StringContent(item.Descricao), "Descricao");
            content.Add(new StringContent(item.Valor.ToString()), "Valor");
            content.Add(new StringContent(item.Categoria), "Categoria");
            content.Add(new StringContent(item.Tamanho.ToString()), "Tamanho");
            content.Add(new StringContent(item.NomeImagem), "NomeImagem");
            content.Add(new StringContent(user.Id), "RestauranteId");
            content.Add(new StreamContent(item.Imagem.OpenReadStream()), "Imagem", name);

            using (var httpClient = new HttpClient())
            {
                var url = _configuration["UrlAPICliente:UrlBase"] + "/Cardapio";
                using (var resposta = await httpClient.PutAsync(url, content))
                {
                    string respostaApi = await resposta.Content.ReadAsStringAsync();
                    var itemView = JsonConvert.DeserializeObject<ItemView>(respostaApi);
                }
            }
            return RedirectToAction(nameof(GetAll));
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult> Delete(Guid id) {
            using (var httpClient = new HttpClient())
            {
                var url = _configuration["UrlAPICliente:UrlBase"] + $"/Cardapio/getitem/{id}";
                using (var resposta = await httpClient.GetAsync(url))
                {
                    string respostaApi = await resposta.Content.ReadAsStringAsync();
                    var r = JsonConvert.DeserializeObject<Item>(respostaApi);
                    if (r != null)
                    {
                        return View(r);
                    }
                }
            }
            return BadRequest();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<ActionResult> Deletar(Item item)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var url = _configuration["UrlAPICliente:UrlBase"] + $"/Cardapio/{item.Id}";
                    using (var resposta = await httpClient.DeleteAsync(url))
                    {
                        string respostaApi = await resposta.Content.ReadAsStringAsync();
                        return RedirectToAction(nameof(GetAll));
                    }
                }
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
