using Dominio_FroFood.Models;
using System.Collections.Generic;

namespace Dominio_FroFood.Servico
{
    public interface IServicoDeBusca
    {
        IEnumerable<Restaurante> MaiorAvaliacaoAsync();
    }
}
