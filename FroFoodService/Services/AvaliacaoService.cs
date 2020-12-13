using Dominio_FroFood.Interfaces.Repositorio;
using Dominio_FroFood.Interfaces.Servico;
using Dominio_FroFood.Models;

namespace FroFoodService.Services
{
    public class AvaliacaoService : ServicoBase<Avaliacao, IAvaliacaoRepositorio>, IAvaliacaoService
    {
        public AvaliacaoService(IAvaliacaoRepositorio repositorio) : base(repositorio)
        {

        }
    }
}
