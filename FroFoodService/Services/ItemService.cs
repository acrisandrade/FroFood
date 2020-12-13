using Dominio_FroFood.Interfaces.Repositorio;
using Dominio_FroFood.Interfaces.Servico;
using Dominio_FroFood.Models;

namespace FroFoodService.Services
{
    public class ItemService : ServicoBase<Item, IItemRepositorio>, IItemService
    {
        public ItemService(IItemRepositorio repositorio) : base(repositorio)
        {
        }
    }
}
