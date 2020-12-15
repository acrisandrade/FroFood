using Dominio_FroFood.Interfaces.Repositorio;
using Dominio_FroFood.Models;
using FroFoodDados.ContextoDeDados;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace FroFoodDados.Repositorios
{
    public class RestauranteRepositorio : RepositorioBase<Restaurante>, IRestauranteRepositorio
    {
        public RestauranteRepositorio(FroFoodContexto contexto) : base(contexto)
        {
        }

        public override async Task<Restaurante> BuscarAsync(Guid Id)
        {
            try
            {
                var r = await _setContext.Include(r => r.Cardapio).SingleAsync(rest => Id == rest.Id);
                return r;
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }
    }
}
