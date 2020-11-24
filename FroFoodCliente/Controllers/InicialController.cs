using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio_FroFood.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FroFoodCliente.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InicialController : ControllerBase
    {
        [HttpGet]
        public List<RestauranteView> BuscarTopDoze()
        {
            IEnumerable<RestauranteView> res = new List<RestauranteView>() {
                new RestauranteView { Nome = "primeiro", Avaliacao = 4.5m },
                new RestauranteView { Nome = "segundo", Avaliacao = 1.5m },
                new RestauranteView { Nome = "terceiro", Avaliacao = 2.5m },
                new RestauranteView { Nome = "quarto", Avaliacao = 3.5m },
                new RestauranteView { Nome = "quinto", Avaliacao = 2.5m },
                new RestauranteView { Nome = "sexto", Avaliacao = 4.5m },
                new RestauranteView { Nome = "sétimo", Avaliacao = 5m },
                new RestauranteView { Nome = "oitavo", Avaliacao = 5m },
                new RestauranteView { Nome = "nono", Avaliacao = 3.5m },
                new RestauranteView { Nome = "decimo", Avaliacao = 2.5m },
                new RestauranteView { Nome = "decimo primeiro", Avaliacao = 0m },
                new RestauranteView { Nome = "decimo segundo", Avaliacao = 0m },
                new RestauranteView { Nome = "decimo terceiro", Avaliacao = 4.5m },
                new RestauranteView { Nome = "FroFood o decimo quarto", Avaliacao = 1.5m },
                new RestauranteView { Nome = "FroFood o decimo quinto", Avaliacao = 2.5m },
                new RestauranteView { Nome = "FroFood o decimo sexto", Avaliacao = 3.5m },
                new RestauranteView { Nome = "FroFood o decimo sétimo", Avaliacao = 2.5m },
                new RestauranteView { Nome = "FroFood o decimo oitavo", Avaliacao = 4.5m },
                new RestauranteView { Nome = "FroFood o decimo nono", Avaliacao = 5m },
                new RestauranteView { Nome = "FroFood o vigesimo", Avaliacao = 5m },
                new RestauranteView { Nome = "FroFood o vigesimo primeiro", Avaliacao = 3.5m },
                new RestauranteView { Nome = "FroFood o vigesimo segundo", Avaliacao = 2.5m },
                new RestauranteView { Nome = "FroFood o vigesimo terceiro", Avaliacao = 0m },
                new RestauranteView { Nome = "FroFood o vigesimo quarto", Avaliacao = 5m },
            };

            var maioresAvaliacoes = res.Where(r => r.Avaliacao >= 4.5m).ToList();

            return maioresAvaliacoes;
        }
        
    }
}
