using Dominio_FroFood.Models;
using Dominio_FroFood.ViewModels;
using FroFoodClienteMVC.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FroFoodClienteMVC.Controllers
{
    public class PedidosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _contextAccessor;
        public PedidosController(IConfiguration configuration, IHttpContextAccessor contextAccessor, ApplicationDbContext context)
        {
            _configuration = configuration;
            _contextAccessor = contextAccessor;
            _context = context;
        }

        [HttpGet]
        public IActionResult Pedido()
        {
            var e = new PedidoView();

            if (TempData["pedido"] != null)
            {
                e = JsonConvert.DeserializeObject<PedidoView>((string)TempData["pedido"]);
            }
            
            return View(e);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ConfirmarPedido([FromForm] string restaurante, string cliente, string valor, string item, string pagamento, string observacao)
        {
            var pedido = new PedidoView()
            {
                Restaurante = Guid.Parse(restaurante),
                Cliente = Guid.Parse(cliente),
                Valor = Decimal.Parse(valor),
                Pagamento = Enum.Parse<FormaPagamento>(pagamento, true),
                Observacao = observacao,
            };

            using (var httpClient = new HttpClient())
            {
                var url = _configuration["UrlAPICliente:UrlBase"] + $"/Items/{item}";
                using var resposta = await httpClient.GetAsync(url);
                string apiResposta = await resposta.Content.ReadAsStringAsync();
                pedido.Item = JsonConvert.DeserializeObject<ItemView>(apiResposta);
            }


            
            StringContent content = new StringContent(JsonConvert.SerializeObject(pedido), Encoding.UTF8, "application/json");
            using (var httpClient = new HttpClient())
            {
                var url = _configuration["UrlAPICliente:UrlBase"] + $"/Pedidos";
                using var resposta = await httpClient.PostAsync(url, content);
                //string apiResposta = await resposta.Content.ReadAsStringAsync();
                //item = JsonConvert.DeserializeObject<PedidoView>(apiResposta);
                //TempData["pedido"] = JsonConvert.SerializeObject(pedido);
            }
            return RedirectToAction(nameof(Listar));
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> Listar()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var email = _contextAccessor.HttpContext.User.Identity.Name;
            var user = _context.Users.FirstOrDefault(u => u.UserName == email);

            var id = Guid.Parse(user.Id);

            var peview = new List<PedidoView>();

            //StringContent content = new StringContent(JsonConvert.SerializeObject(pedido), Encoding.UTF8, "application/json");
            using (var httpClient = new HttpClient())
            {
                var url = _configuration["UrlAPICliente:UrlBase"] + $"/Pedidos/listar/{id}";
                using var resposta = await httpClient.GetAsync(url);
                string apiResposta = await resposta.Content.ReadAsStringAsync();
                peview = JsonConvert.DeserializeObject<List<PedidoView>>(apiResposta);
            }
            return View(peview);
        }

        
    }
}
