using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio_FroFood.Models
{
    public class Restaurante : Usuario
    {
        public string Descricao { get; set; }
        public Endereco Local { get; set; }
        public IEnumerable<Avaliacao> Avaliacoes { get; set;}
        public IEnumerable<Pedido> HistoricoPedidos { get; set; }
        public IEnumerable<Item> Cardapio { get; set; }
        public FormaPagamento Pagamento { get; set; }
        //TODO
        //Imagem

    }
}
