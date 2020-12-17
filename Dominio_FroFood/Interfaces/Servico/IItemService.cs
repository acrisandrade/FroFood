using Dominio_FroFood.Models;
using FroFoodService.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dominio_FroFood.Interfaces.Servico
{
    public interface IItemService : IServicoBase<Item>
    {
        IEnumerable<Item> BuscarItems(string busca);
        IEnumerable<Item> BuscarItemsPorUsuario(Guid id);
    }
}
