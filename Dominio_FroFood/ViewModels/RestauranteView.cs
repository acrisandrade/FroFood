using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio_FroFood.ViewModels
{
    public class RestauranteView
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public Decimal Avaliacao { get; set; }
        public string Descricao { get; set; }

        //TODO
        //Implementar imagem

    }
}
