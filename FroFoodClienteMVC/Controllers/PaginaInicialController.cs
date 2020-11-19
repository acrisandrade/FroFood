using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio_FroFood.Models;
using Microsoft.AspNetCore.Mvc;

namespace FroFoodClienteMVC.Controllers
{
    public class PaginaInicialController : Controller
    {
        public IActionResult Index()
        {
            IEnumerable<Restaurante> res = new List<Restaurante>();
            var r = new Restaurante();
            r.Nome = "FroFood o primeiro";
            res.Append(r);
            return View(res);
        }
    }
}
