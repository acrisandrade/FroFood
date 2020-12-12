using Dominio_FroFood.Models;
using FroFoodDados.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace FroFoodService.Services
{
    public class ClienteService : ServicoBase<Cliente, ClienteRepositorio>
    {
        public ClienteService(ClienteRepositorio repositorio) : base(repositorio)
        {
        }
    }
}
