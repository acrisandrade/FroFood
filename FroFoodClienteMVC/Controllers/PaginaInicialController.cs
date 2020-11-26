using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
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
        public IActionResult Login()
        {
            return View();
        }
       /* public async Task<IActionResult> ResultadoBusca()
        {
            List<RestauranteView> listaBusca = new List<RestauranteView>();
            using (var httpClient = new HttpClient())
            {
               var url = _configuration["UrlAPICliente:UrlBase"] + "/inicial";
                using (var resposta = await httpClient.PostAsync(url, ))
                {
                    string respostaApi = await resposta.Content.ReadAsStringAsync();
                    listaBusca = JsonConvert.DeserializeObject<List<RestauranteView>>(respostaApi);
                }
            }
                return View(listaBusca);
        }*/

        public async Task<IActionResult> InfoRestaurante(int id)
        {
            List <RestauranteView> restaurante = new List <RestauranteView>();
            using (var httpClient = new HttpClient()) {
                var url = _configuration["UrlAPICliente:UrlBase"] + "/inicial";
                using (var resposta = await httpClient.GetAsync(url))
                {
                    string apiResposta = await resposta.Content.ReadAsStringAsync();
                    restaurante = JsonConvert.DeserializeObject<List<RestauranteView >>(apiResposta);
                }

                    return View(restaurante);
            }
        }
    }
}
