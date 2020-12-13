using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FroFoodDados.ContextoDeDados;
using Dominio_FroFood.Interfaces.Repositorio;
using FroFoodDados.Repositorios;

namespace FroFoodCrossCut.InjecaoDependencias
{
    public class ConfiguracaoRepositorio
    {
        public static void ConfDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IAvaliacaoRepositorio, AvaliacaoRepositorio>();
            serviceCollection.AddScoped<IPedidoRepositorio, PedidoRepositorio>();
            serviceCollection.AddScoped<IClienteRepositorio, ClienteRepositorio>();

            serviceCollection.AddDbContext<FroFoodContexto>(
                options => options.UseSqlServer("Server = (localdb)\\mssqllocaldb;Database=FroFoodProject;Trusted_Connection=True;MultipleActiveResultSets=true")
            );
        }
    }
}
