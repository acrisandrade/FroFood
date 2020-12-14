using Dominio_FroFood.Interfaces.Repositorio;
using Dominio_FroFood.Models;
using FroFoodDados.ContextoDeDados;
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

        public IEnumerable<Item> BuscarItems(string busca)
        {
            var item = _setContext.Where(i => i.Nome.ToLower().Contains(busca.ToLower())).ToList();
            return item;
        }
    }
}
