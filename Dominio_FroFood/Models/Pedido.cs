using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio_FroFood.Models
{
   public class Pedido : ClasseBase
    {
        public Decimal Valor { get; set; }
        public string Observacao { get; set; }
        public IEnumerable<Item> Itens { get; set; }
        public Restaurante Restaurante { get; set; }
        public Cliente Cliente { get; set; }
        public FormaPagamento Pagamento { get; set; }
        public string Status { get; set; }
    }
}
