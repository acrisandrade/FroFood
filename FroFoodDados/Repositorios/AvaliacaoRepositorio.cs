using Dominio_FroFood.Models;
using FroFoodDados.ContextoDeDados;
using System;
using System.Collections.Generic;
using System.Text;

namespace FroFoodDados.Repositorios
{
    public class AvaliacaoRepositorio : RepositorioBase<Avaliacao>
    {
        public AvaliacaoRepositorio(FroFoodContexto contexto) : base(contexto)
        {
        }
    }
}
