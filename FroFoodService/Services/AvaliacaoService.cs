using Dominio_FroFood.Interfaces.Repositorio;
using Dominio_FroFood.Interfaces.Servico;
using Dominio_FroFood.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FroFoodService.Services
{
    public class AvaliacaoService : ServicoBase<Avaliacao, IAvaliacaoRepositorio>, IAvaliacaoService
    {
        public AvaliacaoService(IAvaliacaoRepositorio repositorio) : base(repositorio)
        {

        }

        public async Task<IEnumerable<Avaliacao>> buscarAvalicaoesCliente(Guid id)
        {
            return await _repositorio.buscarAvalicaoesClietes(id);
        }

        public async Task<IEnumerable<Avaliacao>> buscarAvalicaoesRestaurante(Guid id)
        {
            return await _repositorio.buscarAvalicaoesRestaurante(id);
        }
    }
}
