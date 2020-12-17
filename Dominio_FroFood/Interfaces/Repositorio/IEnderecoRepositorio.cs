using Dominio_FroFood.Models;
using Dominio_FroFood.Repositorios;
using System;
using System.Collections.Generic;

namespace Dominio_FroFood.Interfaces.Repositorio
{
    public interface IEnderecoRepositorio : IRepositorioBase<Endereco>
    {
        public Endereco Adicionar(Endereco entity);
        Endereco Autalizar(Endereco entity);
        bool Excluir(Guid id);
        IEnumerable<Endereco> ListarEnderecos(Guid userId);
    }
}
