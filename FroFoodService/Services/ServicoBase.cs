using Dominio_FroFood.Models;
using FroFoodDados.Repositorios;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FroFoodService.Services
{
    public class ServicoBase<T, TRepository> : IServicoBase<T> where T : ClasseBase
                            where TRepository : RepositorioBase<T>
    {
        protected readonly TRepository _repositorio;

        public ServicoBase(TRepository repositorio)
        {
            _repositorio = repositorio;
        }

        public virtual async Task<IEnumerable<T>> BuscarAsync()
        {
            var resultado = await _repositorio.BuscarAsync();
            return resultado;
        }

        public virtual async Task<T> BuscarAsync(Guid id)
        {
            var resultado = await _repositorio.BuscarAsync(id);
            return resultado;
        }

        public virtual async Task<T> EditarAsync(T entity)
        {
            var resultado = await _repositorio.EditarAsync(entity);
            return resultado;
        }

        public virtual async Task<bool> ExcluirAsync(Guid id)
        {
            var resultado = await _repositorio.ExcluirAsync(id);
            return resultado;
        }
    }
}
