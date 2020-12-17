using Dominio_FroFood.Models;
using FroFoodService.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio_FroFood.Interfaces.Servico
{
    public interface IEnderecoService : IServicoBase<Endereco>
    {
        public Endereco Adicionar(Endereco entity);
        Endereco Autalizar(Endereco entity);
        bool Excluir(Guid id);
        IEnumerable<Endereco> ListarEnderecos(Guid userId);
    }
}
