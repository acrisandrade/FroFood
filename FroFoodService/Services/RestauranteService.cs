using Dominio_FroFood.Models;
using FroFoodDados.Repositorios;

namespace FroFoodService.Services
{
    public class RestauranteService : ServicoBase<Restaurante, RestauranteRepositorio>
    {
        public RestauranteService(RestauranteRepositorio repositorio) : base(repositorio)
        {
        }
    }
}
