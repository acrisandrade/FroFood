using System;
using System.Collections.Generic;
using System.Linq;
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
    public class PaginaInicialController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _contextAccessor;
        public PaginaInicialController(IConfiguration configuration, IHttpContextAccessor contextAccessor, ApplicationDbContext context)
        {
            _configuration = configuration;
            _contextAccessor = contextAccessor;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<RestauranteView> listaDeMelhoresRestaurantes = new List<RestauranteView>();
            using (var httpClient = new HttpClient())
            {
                var url = _configuration["UrlAPICliente:UrlBase"] + "/inicial";
                using  (var resposta = await httpClient.GetAsync(url))
                {
                    string respostaDaAPI = await resposta.Content.ReadAsStringAsync();
                    listaDeMelhoresRestaurantes = JsonConvert.DeserializeObject<List<RestauranteView>>(respostaDaAPI);
                }
            }
            return View(listaDeMelhoresRestaurantes);
        }
        public IActionResult Login()
        {
            return View();
        }

       [HttpGet]
       public async Task<ActionResult> ResultadoBusca(string busca)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var items = new List<ItemView>();
            StringContent content = new StringContent(JsonConvert.SerializeObject(busca), Encoding.UTF8, "application/json");

            using (var httpClient = new HttpClient())
            {
                var url = _configuration["UrlAPICliente:UrlBase"] + "/Items/buscaritems";
                using (var resposta = await httpClient.PostAsync(url, content))
                {
                    string respostaApi = await resposta.Content.ReadAsStringAsync();
                    items = JsonConvert.DeserializeObject<List<ItemView>>(respostaApi);
                }
            }
            return View(items);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> Pedido(Guid id)
        {
            var pedido = new PedidoView();
            var item = new ItemView();
            using (var httpClient = new HttpClient())
            {
                var url = _configuration["UrlAPICliente:UrlBase"] + $"/Items/{id}";
                using (var resposta = await httpClient.GetAsync(url))
                {
                    string apiResposta = await resposta.Content.ReadAsStringAsync();
                    item = JsonConvert.DeserializeObject<ItemView>(apiResposta);
                }

                var b = _contextAccessor.HttpContext.User.Identity.Name;
                var user = _context.Users.FirstOrDefault(u => u.UserName == b);
                if (_contextAccessor.HttpContext.User.Identity.IsAuthenticated)
                {
                    pedido.Cliente = Guid.Parse(user.Id);
                }
                
                pedido.Item = item;
                pedido.Valor = item.Valor;
                pedido.Restaurante = item.RestauranteId;
                TempData["pedido"] = JsonConvert.SerializeObject(pedido);

                if (!ValidarUsuarioNaAPI(Guid.Parse(user.Id)).Result)
                {
                    return RedirectToAction("Index", "Cadastro");
                }
                
                return RedirectToAction("Pedido","Pedidos");
            }
        }

        private async Task<bool> ValidarUsuarioNaAPI(Guid id)
        {
            var userAPI = new ClienteView();
            using (var httpClient = new HttpClient())
            {
                var url = _configuration["UrlAPICliente:UrlBase"] + $"/Clientes/{id}";
                using (var resposta = await httpClient.GetAsync(url))
                {
                    string apiResposta = await resposta.Content.ReadAsStringAsync();
                    userAPI = JsonConvert.DeserializeObject<ClienteView>(apiResposta);
                }
            }
            if (userAPI == null)
            {
                return false;
            }
            return true;
        }
               
    }
}
