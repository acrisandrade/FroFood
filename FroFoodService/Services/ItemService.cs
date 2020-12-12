using Dominio_FroFood.Models;
using FroFoodDados.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace FroFoodService.Services
{
    public class ItemService : ServicoBase<Item, ItemRepositorio>
    {
        public ItemService(ItemRepositorio repositorio) : base(repositorio)
        {
        }
    }
}
