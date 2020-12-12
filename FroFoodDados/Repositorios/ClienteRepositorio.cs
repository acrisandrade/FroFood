﻿using Dominio_FroFood.Models;
using FroFoodDados.ContextoDeDados;
using System;
using System.Collections.Generic;
using System.Text;

namespace FroFoodDados.Repositorios
{
    public class ClienteRepositorio : RepositorioBase<Cliente>
    {
        public ClienteRepositorio(FroFoodContexto contexto) : base(contexto)
        {

        }
    }
}