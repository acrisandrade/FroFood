using Dominio_FroFood.Models;
using Dominio_FroFood.Repositorios;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dominio_FroFood.Interfaces.Repositorio
{
    public interface IAvaliacaoRepositorio : IRepositorioBase<Avaliacao>
    {
        Task<IEnumerable<Avaliacao>> buscarAvalicaoesClietes(Guid id);
        Task<IEnumerable<Avaliacao>> buscarAvalicaoesRestaurante(Guid id);
    }
}
