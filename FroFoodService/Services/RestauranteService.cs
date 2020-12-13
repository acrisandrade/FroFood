using Dominio_FroFood.Interfaces.Repositorio;
using Dominio_FroFood.Interfaces.Servico;
using Dominio_FroFood.Models;

namespace FroFoodService.Services
{
    public class RestauranteService : ServicoBase<Restaurante, IRestauranteRepositorio>, IRestauranteService
    {
        public RestauranteService(IRestauranteRepositorio repositorio) : base(repositorio)
        {
        }
    }
}
