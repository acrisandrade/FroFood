using Dominio_FroFood.Interfaces.Repositorio;
using Dominio_FroFood.Models;
using FroFoodDados.ContextoDeDados;

namespace FroFoodDados.Repositorios
{
    public class ItemRepositorio : RepositorioBase<Item>, IItemRepositorio
    {
        public ItemRepositorio(FroFoodContexto contexto) : base(contexto)
        {
        }
    }
}
