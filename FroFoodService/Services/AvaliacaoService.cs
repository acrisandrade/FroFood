using Dominio_FroFood.Models;
using FroFoodDados.Repositorios;

namespace FroFoodService.Services
{
    public class AvaliacaoService : ServicoBase<Avaliacao, AvaliacaoRepositorio>
    {
        public AvaliacaoService(AvaliacaoRepositorio repositorio) : base(repositorio)
        {

        }
    }
}
