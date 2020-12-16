using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Dominio_FroFood.ViewModels;
using FroFoodClienteMVC.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace FroFoodClienteMVC.Controllers
{
    [Authorize]
    public class AvaliacaoController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _contextAccessor;
        public AvaliacaoController(IConfiguration configuration, IHttpContextAccessor contextAccessor, ApplicationDbContext context)
        {
            _configuration = configuration;
            _contextAccessor = contextAccessor;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index(Guid id)
        {
            var pedido = new PedidoView();
            using (var httpClient = new HttpClient())
            {
                var url = _configuration["UrlAPICliente:UrlBase"] + $"/Pedidos/{id}";
                using var resposta = await httpClient.GetAsync(url);
                string apiResposta = await resposta.Content.ReadAsStringAsync();
                pedido = JsonConvert.DeserializeObject<PedidoView>(apiResposta);
            }
            return View(pedido);
        }

        [HttpPost]
        public async Task<ActionResult> Avaliar([FromForm] string nota, string comentario, string pedido)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            var avaliacao = new AvaliacaoView() {
                                Nota = Int32.Parse(nota),
                                Comentario = comentario,
                            };

            
            using (var httpClient = new HttpClient())
            {
                var url = _configuration["UrlAPICliente:UrlBase"] + $"/Pedidos/{pedido}";
                using var resposta = await httpClient.GetAsync(url);
                string apiResposta = await resposta.Content.ReadAsStringAsync();
                var p = JsonConvert.DeserializeObject<PedidoView>(apiResposta);
                
                avaliacao.Pedido = p;

                StringContent content = new StringContent(JsonConvert.SerializeObject(avaliacao), Encoding.UTF8, "application/json");
                url = _configuration["UrlAPICliente:UrlBase"] + $"/Avaliacoes";
                using var t = await httpClient.PostAsync(url, content);
                string apir = await t.Content.ReadAsStringAsync();
                avaliacao = JsonConvert.DeserializeObject<AvaliacaoView>(apir);
            }

            return RedirectToAction("Index", "PaginaInicial");
        }
    }
}
