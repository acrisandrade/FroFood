using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
    [Authorize]
    public class HistoricoController : Controller
    {
        private readonly ApplicationDbContext _context;
        private IConfiguration _config;
        private readonly IHttpContextAccessor _contextAccessor;

        public HistoricoController(IConfiguration config, IHttpContextAccessor contextAccessor, ApplicationDbContext context)
        {
            _config = config;
            _contextAccessor = contextAccessor;
            _context = context;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Avaliacao>>> Avalicaoes()
        {
            var email = _contextAccessor.HttpContext.User.Identity.Name;
            var user = _context.Users.FirstOrDefault(u => u.UserName == email);
            var r = new List<Avaliacao>();

            using (var httpClient = new HttpClient())
            {
                var url = _config["UrlAPICliente:UrlBase"] + $"/Avaliacoes/Historico/{user.Id}";
                using (var resposta = await httpClient.GetAsync(url))
                {
                    string respostaApi = await resposta.Content.ReadAsStringAsync();
                    r = JsonConvert.DeserializeObject<List<Avaliacao>>(respostaApi);
                    
                }
            }
            return View(r);
        }
    }
}
