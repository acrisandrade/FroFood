using Dominio_FroFood.Interfaces.Repositorio;
using Dominio_FroFood.Models;
using FroFoodDados.ContextoDeDados;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FroFoodDados.Repositorios
{
    public class ItemRepositorio : RepositorioBase<Item>, IItemRepositorio
    {
        public ItemRepositorio(FroFoodContexto contexto) : base(contexto)
        {
        }

        public override async Task<Item> BuscarAsync(Guid id)
        {
            var item = await _setContext.Include(i => i.Restaurante).SingleOrDefaultAsync(t => t.Id == id);
            return item;
        }

        public override Task<IEnumerable<Item>> BuscarAsync()
        {
            var items = base.BuscarAsync();
            _setContext.Include(i => i.Restaurante);
            return items;
        }

        public IEnumerable<Item> BuscarItems(string busca)
        {
            var item = _setContext.Include(i => i.Restaurante).Where(i => i.Nome.ToLower().Contains(busca.ToLower())).ToList();
            return item;
        }
    }
}
