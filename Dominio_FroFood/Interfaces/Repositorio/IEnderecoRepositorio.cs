using Dominio_FroFood.Models;
using Dominio_FroFood.Repositorios;

namespace Dominio_FroFood.Interfaces.Repositorio
{
    public interface IEnderecoRepositorio : IRepositorioBase<Endereco>
    {
        public Endereco Adicionar(Endereco entity);
    }
}
