using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Dominio_FroFood.Models;
using Dominio_FroFood.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FroFoodClienteMVC.Controllers
{
    public class RestauranteController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index(Guid id)
        {
            //https://localhost:44354/restaurante/index/26b34a6f-8604-4cad-a743-27780c572ffa

            var r = new RestauranteView();
            using (var httpClient = new HttpClient())
            {
                var url = "https://localhost:44399/api/restaurantes";
                using (var resposta = await httpClient.GetAsync($"{url}/{id}"))
                {
                    string respostaDaAPI = await resposta.Content.ReadAsStringAsync();
                    r = JsonConvert.DeserializeObject<RestauranteView>(respostaDaAPI);
                }
            }
            return View("InfoRestaurante", r);
        }
    }
}
