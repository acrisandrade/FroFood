using Dominio_FroFood.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio_FroFood.ViewModels
{
    public class PerfilCliente
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Imagem { get; set; }
        public IEnumerable<Endereco> Enderecos {get; set;}
    }
}
