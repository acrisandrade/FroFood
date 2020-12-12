using System;

namespace Dominio_FroFood.Models
{
    public class ItemPedido
    {
        public Guid ItemId { get; set; }
        public Guid PedidoId { get; set; }
        public Item Item { get; set; }
        public Pedido Pedido { get; set; }
    }
}
