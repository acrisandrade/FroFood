using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio_FroFood.Models
{
    public abstract class Usuario : ClasseBase
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public Endereco Endereco { get; set; }
    }
}
