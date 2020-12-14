using Dominio_FroFood.Models;
using FroFoodService.Services;
using System.Collections.Generic;

namespace Dominio_FroFood.Interfaces.Servico
{
    public interface IItemService : IServicoBase<Item>
    {
        IEnumerable<Item> BuscarItems(string busca);
    }
}
