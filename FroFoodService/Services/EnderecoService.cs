using Dominio_FroFood.Models;
using FroFoodDados.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace FroFoodService.Services
{
    public class EnderecoService : ServicoBase<Endereco, EnderecoRepositorio>
    {
        public EnderecoService(EnderecoRepositorio repositorio) : base(repositorio)
        {
        }
    }
}
