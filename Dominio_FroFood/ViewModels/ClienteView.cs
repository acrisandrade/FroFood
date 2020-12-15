using Dominio_FroFood.Models;
using System;

namespace Dominio_FroFood.ViewModels
{
    public class ClienteView
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public Endereco Endereco { get; set; }
    }
}
