using Dominio_FroFood.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio_FroFood.Servico
{
    public interface ServicoDeBusca
    {
        IEnumerable<Restaurante> MaiorAvaliacaoAsync();
    }
}
