using Dominio_FroFood.Models;
using Dominio_FroFood.Repositorios;
using FroFoodDados.ContextoDeDados;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FroFoodDados.Repositorios
{
    public class RepositorioBase<T> : IRepositorioBase<T> where T : ClasseBase
    {
        protected readonly FroFoodContexto _contexto;
        protected readonly DbSet<T> _setContext;

        public RepositorioBase(FroFoodContexto contexto)
        {
            _contexto = contexto;
            _setContext = _contexto.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> BuscarAsync()
        {
            try
            {
                var todos = await _setContext.ToListAsync();
                return todos;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual async Task<T> BuscarAsync(Guid Id)
        {
            try
            {
                var resultado = await _setContext.SingleOrDefaultAsync(t => t.Id == Id);
                return resultado;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual async Task<T> EditarAsync(T entity)
        {
            try
            {
                var resultado = await BuscarAsync(entity.Id);
                if (resultado == null)
                {
                    return null;
                }
                resultado.DataAtualizao = DateTime.UtcNow;
                _contexto.Entry(resultado).CurrentValues.SetValues(entity);
                await _contexto.SaveChangesAsync();
                return await BuscarAsync(resultado.Id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual async Task<bool> ExcluirAsync(Guid id)
        {
            try
            {
                var resultado = await BuscarAsync(id);
                if (resultado == null)
                {
                    return false;
                }
                _setContext.Remove(resultado);
                await _contexto.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
