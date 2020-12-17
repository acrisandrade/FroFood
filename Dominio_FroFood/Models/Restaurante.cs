using System.Collections.Generic;

namespace Dominio_FroFood.Models
{
    public class Restaurante : Usuario
    {
        public string Descricao { get; set; }
        public IEnumerable<Pedido> HistoricoPedidos { get; set; }
        public IEnumerable<Item> Cardapio { get; set; }
        public FormaPagamento Pagamento { get; set; }
        public Endereco Endereco { get; set; }

    }
}
