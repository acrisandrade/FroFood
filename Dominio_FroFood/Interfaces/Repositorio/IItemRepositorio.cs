using Dominio_FroFood.Models;
using Dominio_FroFood.Repositorios;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dominio_FroFood.Interfaces.Repositorio
{
    public interface IItemRepositorio : IRepositorioBase<Item>
    {
        IEnumerable<Item> BuscarItems(string busca);
        IEnumerable<Item> BuscarItemsPorUsuario(Guid id);
    }
}
