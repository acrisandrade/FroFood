using Dominio_FroFood.Interfaces.Repositorio;
using Dominio_FroFood.Interfaces.Servico;
using Dominio_FroFood.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public IEnumerable<Item> BuscarItemsPorUsuario(Guid id)
        {
            var items = _repositorio.BuscarItemsPorUsuario(id);
            return items;
        }
    }
}
