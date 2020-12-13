﻿using Dominio_FroFood.Interfaces.Repositorio;
using Dominio_FroFood.Models;
using FroFoodDados.ContextoDeDados;

namespace FroFoodDados.Repositorios
{
    public class AvaliacaoRepositorio : RepositorioBase<Avaliacao>, IAvaliacaoRepositorio
    {
        public AvaliacaoRepositorio(FroFoodContexto contexto) : base(contexto)
        {
        }
    }
}
