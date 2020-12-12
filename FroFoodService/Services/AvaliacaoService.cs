using Dominio_FroFood.Models;
using FroFoodDados.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace FroFoodService.Services
{
    public class AvaliacaoService : ServicoBase<Avaliacao, AvaliacaoRepositorio>
    {
        public AvaliacaoService(AvaliacaoRepositorio repositorio) : base(repositorio)
        {

        }
    }
}
