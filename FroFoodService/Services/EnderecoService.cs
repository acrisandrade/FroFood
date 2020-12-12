using Dominio_FroFood.Models;
using FroFoodDados.Repositorios;

namespace FroFoodService.Services
{
    public class EnderecoService : ServicoBase<Endereco, EnderecoRepositorio>
    {
        public EnderecoService(EnderecoRepositorio repositorio) : base(repositorio)
        {
        }
    }
}
