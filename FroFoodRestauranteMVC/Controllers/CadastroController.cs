using System;
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
    public class CadastroController : Controller
    {
        private readonly ApplicationDbContext _context;
        private IConfiguration _config;
        private readonly IHttpContextAccessor _contextAccessor;

        public CadastroController(IConfiguration config, IHttpContextAccessor contextAccessor, ApplicationDbContext context)
        {
            _config = config;
            _contextAccessor = contextAccessor;
            _context = context;
        }

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Cadastrar(IFormCollection collection)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var restaurante = new Restaurante()
            {
                Nome = collection["Nome"],
                Telefone = collection["Telefone"],
                Descricao = collection["Descricao"],
            };

            var endereco = new Endereco()
            {
                Rua = collection["Rua"],
                Bairro = collection["Bairro"],
                Cidade = collection["Cidade"],
                Estado = collection["Estado"],
                Numero = collection["Numero"],
            };

            restaurante.Endereco = endereco;

            var email = _contextAccessor.HttpContext.User.Identity.Name;
            var user = _context.Users.FirstOrDefault(u => u.UserName == email);

            restaurante.Id = Guid.Parse(user.Id);
            restaurante.Email = email;

            

            StringContent content = new StringContent(JsonConvert.SerializeObject(restaurante), Encoding.UTF8, "application/json");
            using (var httpClient = new HttpClient())
            {
                var url = _config["UrlAPICliente:UrlBase"] + $"/Cadastro";
                using var resposta = await httpClient.PostAsync(url, content);
            }
            
            return RedirectToAction("Index","Cardapio");
        }
    }
}
