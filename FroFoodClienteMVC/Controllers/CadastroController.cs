﻿using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Dominio_FroFood.Models;
using Dominio_FroFood.ViewModels;
using FroFoodClienteMVC.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace FroFoodClienteMVC.Controllers
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
        
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var cliente = new ClienteView() 
            {
                Nome = collection["Nome"],
                Telefone = collection["Telefone"],
            };

            var endereco = new Endereco()
            {
                Rua = collection["Rua"],
                Bairro = collection["Bairro"],
                Cidade = collection["Cidade"],
                Estado = collection["Estado"],
                Numero = collection["Numero"],
            };

            var email = _contextAccessor.HttpContext.User.Identity.Name;
            var user = _context.Users.FirstOrDefault(u => u.UserName == email);
            
            cliente.Id = Guid.Parse(user.Id);
            cliente.Email = email;

            cliente.Endereco = endereco;

            StringContent content = new StringContent(JsonConvert.SerializeObject(cliente), Encoding.UTF8, "application/json");
            using (var httpClient = new HttpClient())
            {
                var url = _config["UrlAPICliente:UrlBase"] + $"/Clientes";
                using var resposta = await httpClient.PostAsync(url, content);
            }

            var e = JsonConvert.DeserializeObject<PedidoView>((string)TempData["pedido"]);
            return View("~/Views/Pedidos/Pedido.cshtml", e);
        }
    }
}