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

        public override async Task<Restaurante> AdicionarAsync(Restaurante entity)
        {
            var r = new Restaurante();
            try
            {
                entity.Endereco.Id = Guid.NewGuid();
                _contexto.Set<Restaurante>().Include(e => e.Endereco);
                await _setContext.AddAsync(entity);
                await _contexto.SaveChangesAsync();
                r = await base.BuscarAsync(entity.Id);
            }
            catch (Exception)
            {
                return new Restaurante();
            }

            return r;
        }
    }

    
}
