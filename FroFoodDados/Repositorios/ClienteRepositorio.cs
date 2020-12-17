using Dominio_FroFood.Interfaces.Repositorio;
using Dominio_FroFood.Models;
using FroFoodDados.ContextoDeDados;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace FroFoodDados.Repositorios
{
    public class ClienteRepositorio : RepositorioBase<Cliente>, IClienteRepositorio
    {
        public ClienteRepositorio(FroFoodContexto contexto) : base(contexto)
        {

        }

        public override Task<Cliente> BuscarAsync(Guid Id)
        {
            var resultado = _setContext.Include(c => c.Endereco).SingleOrDefaultAsync(t => t.Id == Id);
            return resultado;
        }

        public override async Task<Cliente> AdicionarAsync(Cliente entity)
        {
            var c = new Cliente();
            try
            {
                //entity.Endereco.Id = Guid.NewGuid();
                _contexto.Set<Cliente>().Include(e => e.Endereco);
                await _setContext.AddAsync(entity);
                await _contexto.SaveChangesAsync();

                c = await base.BuscarAsync(entity.Id);
            } catch (Exception e)
            {
                return new Cliente();
            }
            
            return c;
        }
    }
}
