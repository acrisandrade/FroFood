using Dominio_FroFood.Models;
using FroFoodDados.Repositorios;

namespace FroFoodService.Services
{
    public class ItemService : ServicoBase<Item, ItemRepositorio>
    {
        public ItemService(ItemRepositorio repositorio) : base(repositorio)
        {
        }
    }
}
