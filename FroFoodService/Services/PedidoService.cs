using Dominio_FroFood.Interfaces.Repositorio;
using Dominio_FroFood.Interfaces.Servico;
using Dominio_FroFood.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FroFoodService.Services
{
    public class PedidoService : ServicoBase<Pedido, IPedidoRepositorio>, IPedidoService
    {
        
        public PedidoService(IPedidoRepositorio repositorio) : base(repositorio)
        {
            
        }

        public async Task<IEnumerable<Pedido>> buscarPorUsuario(Guid id)
        {
            var resultado = await _repositorio.buscarPorUsuario(id);
            return resultado;
        }

        

    }
}
