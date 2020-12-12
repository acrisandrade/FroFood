using Dominio_FroFood.Models;
using FroFoodDados.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace FroFoodService.Services
{
    public class RestauranteService : ServicoBase<Restaurante, RestauranteRepositorio>
    {
        public RestauranteService(RestauranteRepositorio repositorio) : base(repositorio)
        {
        }
    }
}
