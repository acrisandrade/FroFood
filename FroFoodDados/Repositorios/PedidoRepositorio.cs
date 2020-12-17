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
    public class PedidoRepositorio : RepositorioBase<Pedido>, IPedidoRepositorio
    {
        public PedidoRepositorio(FroFoodContexto contexto) : base(contexto)
        {
        }

        public override async Task<Pedido> BuscarAsync(Guid Id)
        {
            var resultado = await _setContext.Include(p => p.Cliente).Include(r => r.Restaurante)
                                             .Include(p => p.Itens).ThenInclude(p => p.Item).Where(c => c.Id == Id).SingleOrDefaultAsync();
            return resultado;
        }

        public async Task<IEnumerable<Pedido>> buscarPorUsuario(Guid id)
        {
            var resultado = await _setContext.Include(p => p.Cliente).Include(r => r.Restaurante)
                                             .Include(p => p.Itens).ThenInclude(p => p.Item).Where(c => c.Cliente.Id == id).ToListAsync();
            return resultado;
        }
    }
}
