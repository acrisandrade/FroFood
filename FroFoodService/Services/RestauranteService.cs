using Dominio_FroFood.Interfaces.Repositorio;
using Dominio_FroFood.Interfaces.Servico;
using Dominio_FroFood.Models;
using System.Threading.Tasks;

namespace FroFoodService.Services
{
    public class RestauranteService : ServicoBase<Restaurante, IRestauranteRepositorio>, IRestauranteService
    {
        public RestauranteService(IRestauranteRepositorio repositorio) : base(repositorio)
        {
        }

        public override async Task<Restaurante> AdicionarAsync(Restaurante entity)
        {
            return await _repositorio.AdicionarAsync(entity);
        }
    }
}
