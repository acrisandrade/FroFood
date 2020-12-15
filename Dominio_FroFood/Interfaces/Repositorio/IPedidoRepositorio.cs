using Dominio_FroFood.Models;
using Dominio_FroFood.Repositorios;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dominio_FroFood.Interfaces.Repositorio
{
    public interface IPedidoRepositorio : IRepositorioBase<Pedido>
    {
        Task<IEnumerable<Pedido>> buscarPorUsuario(Guid id);

    }
}
