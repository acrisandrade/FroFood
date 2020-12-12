using Dominio_FroFood.Models;
using FroFoodDados.ContextoDeDados;

namespace FroFoodDados.Repositorios
{
    public class ItemRepositorio : RepositorioBase<Item>
    {
        public ItemRepositorio(FroFoodContexto contexto) : base(contexto)
        {
        }
    }
}
