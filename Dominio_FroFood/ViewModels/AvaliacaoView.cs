using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio_FroFood.ViewModels
{
    public class AvaliacaoView
    {
        public string Comentario { get; set; }
        public int Nota { get; set; }
        public PedidoView Pedido { get; set; }
        public Guid RestauranteID { get; set; }
        public Guid ClienteID { get; set; }
    }
}
