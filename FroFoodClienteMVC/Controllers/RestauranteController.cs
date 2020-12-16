using System;
using System.Net.Http;
using System.Threading.Tasks;
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
            //https://localhost:44354/restaurante/index/1568a21f-3ad8-4641-ad43-ae3b7026fa73

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
