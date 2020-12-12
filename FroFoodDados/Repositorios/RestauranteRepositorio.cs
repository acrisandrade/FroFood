using Dominio_FroFood.Models;
using FroFoodDados.ContextoDeDados;
using System;
using System.Collections.Generic;
using System.Text;

namespace FroFoodDados.Repositorios
{
    public class RestauranteRepositorio : RepositorioBase<Restaurante>
    {
        public RestauranteRepositorio(FroFoodContexto contexto) : base(contexto)
        {
        }
    }
}
