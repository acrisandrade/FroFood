using Dominio_FroFood.Models;
using FroFoodDados.ContextoDeDados;

namespace FroFoodDados.Repositorios
{
    public class RestauranteRepositorio : RepositorioBase<Restaurante>
    {
        public RestauranteRepositorio(FroFoodContexto contexto) : base(contexto)
        {
        }
    }
}
