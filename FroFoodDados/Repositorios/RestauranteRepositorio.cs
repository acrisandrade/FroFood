using Dominio_FroFood.Interfaces.Repositorio;
using Dominio_FroFood.Models;
using FroFoodDados.ContextoDeDados;

namespace FroFoodDados.Repositorios
{
    public class RestauranteRepositorio : RepositorioBase<Restaurante>, IRestauranteRepositorio
    {
        public RestauranteRepositorio(FroFoodContexto contexto) : base(contexto)
        {
        }
    }
}
