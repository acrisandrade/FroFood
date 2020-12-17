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
    public class AvaliacaoRepositorio : RepositorioBase<Avaliacao>, IAvaliacaoRepositorio
    {
        public AvaliacaoRepositorio(FroFoodContexto contexto) : base(contexto)
        {
        }

        public async Task<IEnumerable<Avaliacao>> buscarAvalicaoesClietes(Guid id)
        {
            try
            {
                var reultado = await _setContext.Include(a => a.Cliente).Where(c => c.Cliente.Id == id).ToListAsync();
                return reultado;
            } 
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<IEnumerable<Avaliacao>> buscarAvalicaoesRestaurante(Guid id)
        {
            try
            {
                var reultado = await _setContext.Include(a => a.Cliente)
                                                .Include(a => a.Pedido)
                                                .ThenInclude(p => p.Itens)
                                                .Include(a => a.Cliente)
                                                .Where(c => c.Restaurante.Id == id).ToListAsync();
                return reultado;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
