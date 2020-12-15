using Dominio_FroFood.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio_FroFood.ViewModels
{
    public class PedidoView
    {
        public Guid Id { get; set; }
        public Decimal Valor { get; set; }
        public string Observacao { get; set; }
        public ItemView Item { get; set; }
        public Guid Restaurante { get; set; }
        public Guid Cliente { get; set; }
        public FormaPagamento Pagamento { get; set; }
        public string Status { get; set; }
    }
}
