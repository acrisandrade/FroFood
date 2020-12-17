using Dominio_FroFood.Interfaces.Repositorio;
using Dominio_FroFood.Interfaces.Servico;
using Dominio_FroFood.Models;
using System;
using System.Collections.Generic;

namespace FroFoodService.Services
{
    public class EnderecoService : ServicoBase<Endereco, IEnderecoRepositorio>, IEnderecoService
    {
        public EnderecoService(IEnderecoRepositorio repositorio) : base(repositorio)
        {
        }

        public Endereco Adicionar(Endereco entity)
        {
            return _repositorio.Adicionar(entity);
        }

        public Endereco Autalizar(Endereco entity)
        {
            return _repositorio.Autalizar(entity);
        }

        public bool Excluir(Guid id)
        {
            return _repositorio.Excluir(id);
        }

        public IEnumerable<Endereco> ListarEnderecos(Guid userId)
        {
            return _repositorio.ListarEnderecos(userId);
        }
    }
}
