using Dominio_FroFood.Models;
using FroFoodService.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dominio_FroFood.Interfaces.Servico
{
    public interface IPedidoService : IServicoBase<Pedido>
    {
        Task<IEnumerable<Pedido>> buscarPorUsuario(Guid id);
    }
}
