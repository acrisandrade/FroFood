using Dominio_FroFood.Models;
using FroFoodService.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dominio_FroFood.Interfaces.Servico
{
    public interface IAvaliacaoService : IServicoBase<Avaliacao>
    {
        Task<IEnumerable<Avaliacao>> buscarAvalicaoesCliente(Guid id);
        Task<IEnumerable<Avaliacao>> buscarAvalicaoesRestaurante(Guid id);
    }
}
