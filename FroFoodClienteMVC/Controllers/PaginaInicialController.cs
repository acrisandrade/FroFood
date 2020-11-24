using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Dominio_FroFood.Models;
using Dominio_FroFood.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace FroFoodClienteMVC.Controllers
{
    public class PaginaInicialController : Controller
    {

        private readonly IConfiguration _configuration;
        public PaginaInicialController(IConfiguration configuration)
        {
            _configuration = configuration;
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
    }
}
