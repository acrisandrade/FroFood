using Dominio_FroFood.Models;
using FroFoodDados.ContextoDeDados;
using System;
using System.Collections.Generic;
using System.Text;

namespace FroFoodDados.Repositorios
{
    public class ItemRepositorio : RepositorioBase<Item>
    {
        public ItemRepositorio(FroFoodContexto contexto) : base(contexto)
        {
        }
    }
}
