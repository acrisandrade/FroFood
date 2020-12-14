using Dominio_FroFood.Models;
using Dominio_FroFood.Repositorios;
using System.Collections.Generic;

namespace Dominio_FroFood.Interfaces.Repositorio
{
    public interface IItemRepositorio : IRepositorioBase<Item>
    {
        IEnumerable<Item> BuscarItems(string busca);
    }
}
