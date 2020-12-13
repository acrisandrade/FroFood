using Dominio_FroFood.Interfaces.Repositorio;
using Dominio_FroFood.Interfaces.Servico;
using Dominio_FroFood.Models;

namespace FroFoodService.Services
{
    public class EnderecoService : ServicoBase<Endereco, IEnderecoRepositorio>, IEnderecoService
    {
        public EnderecoService(IEnderecoRepositorio repositorio) : base(repositorio)
        {
        }
    }
}
