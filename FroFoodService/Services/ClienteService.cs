using Dominio_FroFood.Interfaces.Repositorio;
using Dominio_FroFood.Interfaces.Servico;
using Dominio_FroFood.Models;
using FroFoodDados.Repositorios;
using System.Threading.Tasks;

namespace FroFoodService.Services
{
    public class ClienteService : ServicoBase<Cliente, IClienteRepositorio>, IClienteService
    {
        public ClienteService(IClienteRepositorio repositorio) : base(repositorio)
        {
        }

        public override async Task<Cliente> AdicionarAsync(Cliente entity)
        {
            return await _repositorio.AdicionarAsync(entity);
        }
    }
}
