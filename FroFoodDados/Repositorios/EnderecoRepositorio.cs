using Dominio_FroFood.Models;
using FroFoodDados.ContextoDeDados;

namespace FroFoodDados.Repositorios
{
    public class EnderecoRepositorio : RepositorioBase<Endereco>
    {
        public EnderecoRepositorio(FroFoodContexto contexto) : base(contexto)
        {
        }
    }
}
