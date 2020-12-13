using Dominio_FroFood.Interfaces.Repositorio;
using Dominio_FroFood.Interfaces.Servico;
using Dominio_FroFood.Models;
using FroFoodDados.Repositorios;

namespace FroFoodService.Services
{
    public class ClienteService : ServicoBase<Cliente, IClienteRepositorio>, IClienteService
    {
        public ClienteService(IClienteRepositorio repositorio) : base(repositorio)
        {
        }
    }
}
