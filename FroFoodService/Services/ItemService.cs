using Dominio_FroFood.Interfaces.Repositorio;
using Dominio_FroFood.Interfaces.Servico;
using Dominio_FroFood.Models;
using System.Collections.Generic;

namespace FroFoodService.Services
{
    public class ItemService : ServicoBase<Item, IItemRepositorio>, IItemService
    {
        public ItemService(IItemRepositorio repositorio) : base(repositorio)
        {
        }

        public IEnumerable<Item> BuscarItems(string busca)
        {
            var item = _repositorio.BuscarItems(busca);
            return item;
        }
    }
}
