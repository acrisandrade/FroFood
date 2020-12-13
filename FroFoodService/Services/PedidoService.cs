using Dominio_FroFood.Interfaces.Repositorio;
using Dominio_FroFood.Interfaces.Servico;
using Dominio_FroFood.Models;
using FroFoodDados.Repositorios;

namespace FroFoodService.Services
{
    public class PedidoService : ServicoBase<Pedido, IPedidoRepositorio>, IPedidoService
    {
        public PedidoService(IPedidoRepositorio repositorio) : base(repositorio)
        {
        }
    }
}
