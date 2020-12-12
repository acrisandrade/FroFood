using Dominio_FroFood.Models;
using FroFoodDados.ContextoDeDados;

namespace FroFoodDados.Repositorios
{
    public class AvaliacaoRepositorio : RepositorioBase<Avaliacao>
    {
        public AvaliacaoRepositorio(FroFoodContexto contexto) : base(contexto)
        {
        }
    }
}
