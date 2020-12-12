using Dominio_FroFood.Models;
using FroFoodDados.Repositorios;

namespace FroFoodService.Services
{
    public class ClienteService : ServicoBase<Cliente, ClienteRepositorio>
    {
        public ClienteService(ClienteRepositorio repositorio) : base(repositorio)
        {
        }
    }
}
