using Dominio_FroFood.Interfaces.Servico;
using FroFoodService.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FroFoodCrossCut.InjecaoDependencias
{
    public class ConfiguracaoServicos
    {
        public static void ConfDependenciesServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IAvaliacaoService, AvaliacaoService>();
            serviceCollection.AddTransient<IClienteService, ClienteService>();
            serviceCollection.AddTransient<IEnderecoService, EnderecoService>();
            serviceCollection.AddTransient<IPedidoService, PedidoService>();
            serviceCollection.AddTransient<IRestauranteService, RestauranteService>();
            
            
        }
    }
}
