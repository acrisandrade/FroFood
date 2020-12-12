using Dominio_FroFood.Models;
using FroFoodDados.ContextoDeDados;
using System;
using System.Collections.Generic;
using System.Text;

namespace FroFoodDados.Repositorios
{
    public class EnderecoRepositorio : RepositorioBase<Endereco>
    {
        public EnderecoRepositorio(FroFoodContexto contexto) : base(contexto)
        {
        }
    }
}
