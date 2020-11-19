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
        public Guid RestauranteId { get; set; }
        public Guid ClienteId { get; set; }
        public string Status { get; set; }
    }
}
