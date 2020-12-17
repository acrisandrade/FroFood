using FroFoodRestauranteMVC.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace FroFoodRestauranteMVC.Controllers
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

        public IActionResult Index()
        {
            return View();
        }
    }
}
