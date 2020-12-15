using Dominio_FroFood.Models;
using System;
using System.Collections.Generic;

namespace Dominio_FroFood.ViewModels
{
    public class RestauranteView
    {
        public RestauranteView()
        {
            Cardapio = new List<ItemView>();
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public Decimal Avaliacao { get; set; }
        public string Descricao { get; set; }
        public IList<ItemView> Cardapio { get; set; }

        //TODO
        //Implementar imagem

    }
}
