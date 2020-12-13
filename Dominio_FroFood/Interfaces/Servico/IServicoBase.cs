using Dominio_FroFood.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FroFoodService.Services
{
    public interface IServicoBase<T> where T : ClasseBase
    {
        Task<T> AdicionarAsync(T entity);
        Task<IEnumerable<T>> BuscarAsync();
        Task<T> BuscarAsync(Guid id);
        Task<T> EditarAsync(T entity);
        Task<bool> ExcluirAsync(Guid id);
    }
}